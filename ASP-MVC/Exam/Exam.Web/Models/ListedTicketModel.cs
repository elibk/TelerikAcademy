using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class ListedTicketModel
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }
        public Priority Priority { get; set; }

        public string PriorituValue 
        {   
            get{ return this.Priority.ToString();} 
 
        }
        public static Expression<Func<Ticket, ListedTicketModel>> FromTicket
        {
            get
            {
                return x => new ListedTicketModel()
                {
                    TicketId = x.TicketId,
                    Title = x.Title,
                    AuthorName = x.Author.UserName,
                    CategoryName = x.Category.Name,
                    Priority = x.Priority
                };
            }
        }
    }
}