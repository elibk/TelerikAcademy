using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class RoleInMovie
    {
        public int Id { get; set; }

        [Required]
        public RoleType RoleType { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public MemberInMovie MemberInMovie { get; set; }
    }
  
   
}