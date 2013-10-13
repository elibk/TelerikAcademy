using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketModelSimple
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }
        public int CommentsCount { get; set; }

        public static Expression<Func<Ticket, TicketModelSimple>> FromTicket
        {
            get
            {
                return x => new TicketModelSimple()
                {
                    TicketId = x.TicketId,
                    Title = x.Title,
                    AuthorName = x.Author.UserName,
                    CommentsCount =  x.Comments.Count,
                    CategoryName = x.Category.Name
                };
            }
        }
    }
}