using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
   public class Homework
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }
        public virtual Student Owner { get; set; }
        public virtual Course CourseAssigned { get; set; }

    }
}
