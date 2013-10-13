using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities
{
    public class MemberInMovie
    {
        public int Id { get; set; }

       
        public string Name { get; set; }
        public int Age { get; set; }

        private ICollection<RoleInMovie> roles;
        public MemberInMovie()
        {
            this.roles = new HashSet<RoleInMovie>();
        }
        
        public virtual ICollection<RoleInMovie> Roles
        {
            get
            {
                return this.roles;
            }
            set
            {
                this.roles = value;
            }
        }
    }
}
