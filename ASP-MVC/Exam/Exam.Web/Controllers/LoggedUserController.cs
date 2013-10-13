using Exam.Models;
using Exam.Web.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace Exam.Web.Controllers
{
    [Authorize]
    public class LoggedUserController : BaseController
    {

        private const int PointsForNewTicket = 1; 
        private const Priority DefaultPriority = Priority.Medium;

        //
        // GET: /LoggedUser/
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult CreateTicket(NewTicketModel ticketModel)
        {
            this.LoadDropDownModelsInViewBag();

            if (ModelState.IsValid)
            {
                var userName = this.User.Identity.Name;
                var currentUser = this.Data.Users.All().FirstOrDefault(u => u.UserName == userName);

                var newTicket = new Ticket()
                {
                    Author = currentUser,
                    CategoryId = ticketModel.CategoryId,
                    Description = ticketModel.Description,
                    Priority = (Priority)ticketModel.PriorityValue,
                    UrlScreenshot = ticketModel.UrlScreenshot,
                    Title = ticketModel.Title
                };

                this.Data.Tickets.Add(newTicket);
                currentUser.Points += PointsForNewTicket;
                this.Data.SaveChanges();

                ViewBag.ShowConfirm = true;

                return View();
            }

            
            return View(ticketModel);
        }

        public ActionResult AddTicket()
        {

            this.LoadDropDownModelsInViewBag();
            return View("CreateTicket");
        }

        public JsonResult GetTicketsData([DataSourceRequest]DataSourceRequest request)
        {
            var tickets = this.Data.Tickets.All().Select(ListedTicketModel.FromTicket).OrderBy(t => t.Title);
            return Json(tickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        

        private void LoadDropDownModelsInViewBag()
        {
            var categories = this.Data.Categories.All().OrderBy(c => c.Name).ToList().Select(c => new SelectListItem() { Value = c.CategoryId.ToString(), Text = c.Name }).ToList();

            ViewBag.Categories = categories;


            var priorities = this.PopulatePriorityList();

            ViewBag.Priorities = priorities;
        }

        protected IList<SelectListItem> PopulatePriorityList()
        {
            IList<SelectListItem> priorityList = new List<SelectListItem>();
            foreach (Priority priority in Enum.GetValues(typeof(Priority)))
            {
                SelectListItem item = new SelectListItem()
                {
                    Selected = false,
                    Text = priority.ToString(),
                    Value = ((int)priority).ToString(),
                };

                if (priority == DefaultPriority)
                {
                    item.Selected = true;
                }

                priorityList.Add(item);
            }

            return priorityList;
        }
	}
}