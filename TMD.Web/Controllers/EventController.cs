using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // GET: Event
        public ActionResult Index()
        {
            IEnumerable<EventModel> events = eventService.GetAllEvents().ToList().Select(x => x.CreateFromServerToClient());
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(events);
        }

        public ActionResult Create(int? id)
        {
            var model = new EventModel();
            model.EventDate = DateTime.Now;
            if (id != null)
            {
                var evenT = eventService.GetEvent(id.Value);
                if (evenT != null)
                    model = evenT.CreateFromServerToClient();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EventModel model)
        {
            try
            {
                if (model.EventId == 0)
                {
                    model.RecCreatedBy = User.Identity.GetUserId();
                    model.RecCreatedDate = DateTime.Now;
                }
                model.RecLastUpdatedBy = User.Identity.GetUserId();
                model.RecLastUpdatedDate = DateTime.Now;

                if (eventService.SaveEvent(model.CreateFromClientToServer()) > 0)
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