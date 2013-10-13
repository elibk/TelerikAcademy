using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exam.Web.Models
{
   public class CommentModel
    {
       public int TicketId { get; set; }
        public int CommentId { get; set; }

        public string AuthorName { get; set; }

       [Required]
        public string Content { get; set; }

        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get
            {
                return x => new CommentModel()
                {
                    CommentId = x.CommentId,
                    AuthorName = x.Author.UserName,
                    Content = x.Content,
                    TicketId = x.Ticket.TicketId
                };
            }
        }

    }
}
