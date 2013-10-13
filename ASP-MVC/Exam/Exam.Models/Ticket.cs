using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
   public class Ticket
    {
        public int TicketId { get; set; }

       [Required]
        public string Title { get; set; }

       [Required]
        public virtual ApplicationUser Author { get; set; }

      
        public int CategoryId { get; set; }

      
        public virtual Category Category { get; set; }

       [Required]
        public Priority Priority { get; set; }

        public string UrlScreenshot  { get; set; }

        public string Description { get; set; }


       private ICollection<Comment> comments;
       public Ticket()
        {
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

    }
}
