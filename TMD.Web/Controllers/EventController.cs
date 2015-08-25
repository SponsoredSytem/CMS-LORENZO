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
    public class EventController : Controller
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
                ViewBag.Company = listViewModel.Events.FirstOrDefault().CompanyName;
                Session["CompanyIdForEvent"] = id;
            }
            else
            {
                Session["CompanyIdForEvent"] = null;
            }
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(listViewModel);
        }

        public ActionResult Create(int? id)
        {
            var viewModel = new EventViewModel
            {
                EventModel =
                {
                    EventDate = DateTime.Now.Date,
                    ReminderDate = DateTime.Now.Date
                }
            };
            if (Session["CompanyIdForEvent"] != null)
                viewModel.EventModel.CompanyId = Convert.ToInt64(Session["CompanyIdForEvent"].ToString());

            viewModel.Companies = companyService.GetAllCompanies().ToList().Select(x => x.CreateFromServerToClient());
            viewModel.EventStatuses = eventStatusService.GetAllActiveEventStatuses().ToList().Select(x => x.CreateFromServerToClient());
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
    }
}