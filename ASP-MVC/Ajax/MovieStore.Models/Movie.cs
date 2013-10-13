using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1906, 2050,
        ErrorMessage = "Value for 'Year' must be between 1906 and 2050.")]
        public int Year { get; set; }

        [Required]
        public virtual Studio Studio { get; set; }

         private ICollection<RoleInMovie> artistsRoles;
         public Movie()
        {
            this.artistsRoles = new HashSet<RoleInMovie>();
        }

         public virtual ICollection<RoleInMovie> ArtistsRoles
        {
            get
            {
                return this.artistsRoles;
            }
            set
            {
                this.artistsRoles = value;
            }
        }
    }
}
