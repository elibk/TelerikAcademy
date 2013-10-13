using Microsoft.AspNet.Identity.EntityFramework;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data
{
    public class MovieStoreContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
       public DbSet<Movie> Movies {get; set;}

       public DbSet<Studio> Studios { get; set; }
       public DbSet<MemberInMovie> MembersInMovies { get; set; }
    }
}
