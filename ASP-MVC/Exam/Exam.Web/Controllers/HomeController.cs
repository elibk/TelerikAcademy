using Exam.Models;
using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    public class HomeController : BaseController
    {
        private const int topTicketsCount = 6;
        public ActionResult Index()
        {

            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var listOfTopCommentedTickets = this.Data.Tickets.All()
                    .OrderByDescending(x => x.Comments.Count())
                    .Take(topTicketsCount)
                    .Select(TicketModelSimple.FromTicket);
                // change time to hour
                this.HttpContext.Cache.Add("HomePageTickets", listOfTopCommentedTickets.ToList(), null, DateTime.Now.AddMinutes(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageTickets"]);
        }

        public ActionResult TicketDetails(int ticketId)
        {
            if (this.User.Identity.IsAuthenticated)
	        {
		        ViewBag.IsAutenticated = true;
	        }
            

            var cuurentTicket = this.Data.Tickets.All()
                .Select(TicketModelDetails.FromTicket).FirstOrDefault(t => t.TicketId == ticketId);

            return View(cuurentTicket);
        }

        [Authorize]
        public ActionResult CreateComment(CommentModel model)
        {
            

            if (ModelState.IsValid)
            {
                 var userName = this.User.Identity.Name;
                var currentUser = this.Data.Users.All().FirstOrDefault(u => u.UserName == userName);
                var ticket = this.Data.Tickets.All().FirstOrDefault(t => t.TicketId == model.TicketId);
                var newComment = new Comment
                    {
                        Author = currentUser,
                        Content = model.Content,
                        Ticket = ticket,
                    };
                this.Data.Comments.Add(
                    newComment
                    );

                this.Data.SaveChanges();

                var comments = this.Data.Comments.All().Where(c => c.Ticket.TicketId == model.TicketId).Select(CommentModel.FromComment).ToList();

                return PartialView("_Comments", comments);
            }

            var commentsOld = this.Data.Comments.All().Where(c => c.Ticket.TicketId == model.TicketId).Select(CommentModel.FromComment).ToList();
            ViewBag.ShowError = true;
            return PartialView("_Comments", commentsOld);
        }
    }
}