using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ApplicationUser : User
    {
        private ICollection<Ticket> tickes;
        public ApplicationUser()
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

        public int Points { get; set; }
    }
}
