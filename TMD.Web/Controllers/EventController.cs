using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        private readonly ICompanyService companyService;
        private readonly IEventStatusService eventStatusService;

        public EventController(IEventService eventService, ICompanyService companyService, IEventStatusService eventStatusService)
        {
            this.eventService = eventService;
            this.companyService = companyService;
            this.eventStatusService = eventStatusService;
        }

        // GET: Event
        public ActionResult Index(long? id)
        {
            
            EventListViewModel listViewModel=new EventListViewModel();
            var events = eventService.GetAllEvents(id).ToList();
            listViewModel.Events = events.Select(x => x.CreateFromServerToClient());
            //listViewModel.Companies = companyService.GetAllCompanies().ToList().Select(x => x.CreateFromServerToClient());
            if (id != null && listViewModel.Events.FirstOrDefault() != null)
            {
                ViewBag.Company = "of <span style='color:#FF8E81;'>" + listViewModel.Events.FirstOrDefault().CompanyName + "</span>";
                Session["CompanyIdForEvent"] = id;
                
            }
            else
            {
                Session["CompanyIdForEvent"] = null;
            }
            if (listViewModel.Events.Any())
            {
                var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23,59,59);
                var tomorrow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1, 23, 59, 59);
                listViewModel.TodaysEvents = listViewModel.Events.Count(x => x.EventDate >= DateTime.Now && x.EventDate <= today);
                listViewModel.TomorrowsEvents = listViewModel.Events.Count(x => x.EventDate > today && x.EventDate <= tomorrow);
            }
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            
            return View(listViewModel);
        }

        public ActionResult Calendar()
        {
            var viewModel = new EventViewModel
            {
                Companies = companyService.GetAllCompanies().ToList().Select(x => x.CreateFromServerToClient()),
                EventStatuses =
                    eventStatusService.GetAllActiveEventStatuses().ToList().Select(x => x.CreateFromServerToClient())
            };

            return View(viewModel);
        }
        public ActionResult Create(int? id)
        {
            var viewModel = new EventViewModel();
            viewModel.Companies = companyService.GetAllCompanies().ToList().Select(x => x.CreateFromServerToClient());
            viewModel.EventStatuses = eventStatusService.GetAllActiveEventStatuses().ToList().Select(x => x.CreateFromServerToClient());

            if (Session["CompanyIdForEvent"] != null)
            {
                viewModel.EventModel.CompanyId = Convert.ToInt64(Session["CompanyIdForEvent"].ToString());
                ViewBag.Company = "of <span style='color:#FF8E81;'>" + viewModel.Companies.FirstOrDefault(x => x.CompanyId == Convert.ToInt64(Session["CompanyIdForEvent"].ToString())).CompanyName + "</span>";
            }

            
            if (id == null) return View(viewModel);

            var evenT = eventService.GetEvent(id.Value);
            if (evenT != null)
                viewModel.EventModel = evenT.CreateFromServerToClient();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            try
            {
                if (viewModel.EventModel.EventId == 0)
                {
                    viewModel.EventModel.RecCreatedBy = User.Identity.GetUserId();
                    viewModel.EventModel.RecCreatedDate = DateTime.Now;
                }
                viewModel.EventModel.RecLastUpdatedBy = User.Identity.GetUserId();
                viewModel.EventModel.RecLastUpdatedDate = DateTime.Now;
                viewModel.EventModel.EventDuration = 15;

                if (eventService.SaveEvent(viewModel.EventModel.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Event has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Index", "Event");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
                bool result = eventService.DeleteEvent(eventService.GetEvent(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "Event cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCalendarEvents(DateTime start, DateTime end)
        {
            var events = eventService.GetAllEvents(null).ToList();
            var eventList = from e in events
                            select new
                            {
                                id=e.EventId,
                                title = e.EventDescription,
                                start = string.Format("{0:yyyy-MM-dd}", e.EventDate) + "T" + string.Format("{0:HH:mm:ss}", e.EventDate),
                                end = string.Format("{0:yyyy-MM-dd}", e.EventDate.AddMinutes(e.EventLengthMinutes)) + "T" + string.Format("{0:HH:mm:ss}", e.EventDate.AddMinutes(e.EventLengthMinutes)),
                                allDay = false,
                                color = e.EventStatus.Color,
                                companyid=e.CompanyId,
                                statusId=e.EventStatusId,
                                duration=e.EventLengthMinutes,
                                reminderNote=e.ReminderNote,
                                reminderDate=e.ReminderDate.ToShortDateString(),
                                eventDate=e.EventDate.ToShortDateString(),
                                eventTime=e.EventDate.ToShortTimeString(),
                                recCreatedBy=e.RecCreatedBy,
                                recCreatedDate=e.RecCreatedDate.ToString("G")
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCalendarSummary(DateTime start, DateTime end)
        {
            var events = eventService.GetAllEvents(null).ToList();
            var eventList = from e in events
                            select new
                            {
                                id = e.EventId,
                                title = e.EventDescription,
                                start = string.Format("{0:yyyy-MM-dd}", e.EventDate) + "T" + string.Format("{0:HH:mm:ss}", e.EventDate),
                                end = string.Format("{0:yyyy-MM-dd}", e.EventDate.AddMinutes(e.EventLengthMinutes)) + "T" + string.Format("{0:HH:mm:ss}", e.EventDate.AddMinutes(e.EventLengthMinutes)),
                                allDay = false,
                                color = e.EventStatus.Color,
                                companyid = e.CompanyId,
                                statusId = e.EventStatusId,
                                duration = e.EventLengthMinutes,
                                reminderNote = e.ReminderNote,
                                reminderDate = e.ReminderDate.ToShortDateString(),
                                eventDate = e.EventDate.ToShortDateString(),
                                eventTime = e.EventDate.ToShortTimeString(),
                                recCreatedBy = e.RecCreatedBy,
                                recCreatedDate = e.RecCreatedDate.ToString("G")
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public bool SaveEvent(EventModel eventModel)
        {
            if (eventModel.EventId == 0)
            {
                eventModel.RecCreatedBy = User.Identity.GetUserId();
                eventModel.RecCreatedDate = DateTime.Now;
            }
            eventModel.RecLastUpdatedBy = User.Identity.GetUserId();
            eventModel.RecLastUpdatedDate = DateTime.Now;
            return (eventService.SaveEvent(eventModel.CreateFromClientToServer()) > 0);
        }
    }
}