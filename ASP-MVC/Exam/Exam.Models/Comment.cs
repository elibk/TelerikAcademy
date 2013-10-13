using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
   public class Comment
    {
        public int CommentId { get; set; }

       
        public virtual ApplicationUser Author { get; set; }

        public virtual Ticket Ticket { get; set; }

       [Required]
        public string Content { get; set; }
    }
}
