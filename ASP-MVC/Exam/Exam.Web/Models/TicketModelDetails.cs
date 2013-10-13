using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketModelDetails
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        [DisplayName("Author")]
        public string AuthorName { get; set; }

        public Priority Priority { get; set; }

        [DisplayName("Priority")]
        public string PriorityTitle 
        {
            get { return this.Priority.ToString(); }
        }
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string UrlScreenshot { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
        public static Expression<Func<Ticket, TicketModelDetails>> FromTicket
        {
            get
            {
                return x => new TicketModelDetails()
                {
                    TicketId = x.TicketId,
                    Title = x.Title,
                    AuthorName = x.Author.UserName,
                    CategoryName = x.Category.Name,
                    Priority = x.Priority,
                    Description = x.Description,
                    UrlScreenshot = x.UrlScreenshot,
                    Comments = x.Comments.AsQueryable().Select(CommentModel.FromComment)

                };
            }
        }
    }
}