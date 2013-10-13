using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Web.Models
{
    public class NewTicketModel
    {
        public int TicketId { get; set; }

        [Required]
        [StringNotContains("bug", "The word 'bug' should not be used in the title")]
        public string Title { get; set; }

         [Required]
        [DisplayName("Priority")]
        public int PriorityValue { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

         [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Screenshot URL")]
        public string UrlScreenshot { get; set; }
    }
}
