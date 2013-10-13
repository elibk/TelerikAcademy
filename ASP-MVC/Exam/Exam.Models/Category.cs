using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
   public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        private ICollection<Ticket> tickes;
        public Category()
        {
            this.tickes = new HashSet<Ticket>();
        }

        public virtual ICollection<Ticket> Tickes
        {
            get
            {
                return this.tickes;
            }
            set
            {
                this.tickes = value;
            }
        }
    }
}
