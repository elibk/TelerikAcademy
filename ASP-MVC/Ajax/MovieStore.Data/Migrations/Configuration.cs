namespace MovieStore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using MovieStore.Entities;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<MovieStore.Data.MovieStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MovieStoreContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (context.Roles.FirstOrDefault() == null)
            {
                //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX UX_TagName ON Tags (Name)");
                context.Roles.AddOrUpdate(r => r.Name,
                    new Role("User"),
                    new Role("Admin"));
            }

            if (context.Studios.FirstOrDefault() == null)
            {

                context.Studios.AddOrUpdate(s => s.Name,
                    new Studio()
                    {
                        Name = "21st Century Fox",
                        Address = "1211 Avenue of the Americas, New York, NY 10036, United States"
                    },
                    new Studio()
                    {
                        Name = "Pixar",
                        Address = "Walt Disney Studios, Burbank, California, U.S."
                    },
                    new Studio()
                    {
                        Name = "Warner Bros.",
                        Address = "Burbank, California, U.S."
                    },
                    new Studio()
                    {
                        Name = "Sony Pictures Entertainment",
                        Address = "10202 West Washington Blvd., Culver City, California, United States"
                    });
            }

            if (context.MembersInMovies.FirstOrDefault() == null)
            {

                context.MembersInMovies.AddOrUpdate(s => s.Name,
                new MemberInMovie()
                {
                    Name = "Jack Nicholson FOO",
                    Age = CalculateAge(1937)
                },
                new MemberInMovie()
                {
                    Name = "Brad Pitt FOO",
                    Age = CalculateAge(1963)
                },
                new MemberInMovie()
                {
                    Name = "Robert De Niro FOO",
                    Age = CalculateAge(1943)
                },

                 new MemberInMovie()
                 {
                     Name = "Mila Kunis FOO",
                     Age = CalculateAge(1983)
                 },

                new MemberInMovie()
                {
                    Name = "Amanda Seyfried FOO",
                    Age = CalculateAge(1985)
                },

                 new MemberInMovie()
                 {
                     Name = "Steven Spielberg FOO",
                     Age = CalculateAge(1946)
                 },

                  new MemberInMovie()
                  {
                      Name = "Francis Ford Coppola FOO",
                      Age = CalculateAge(1939)
                  },

                 new MemberInMovie()
                {
                    Name = "Scarlett Johansson FOO",
                    Age = CalculateAge(1984)
                });
            }

        }

        private int CalculateAge(int yearOfBirth)
        {
            return DateTime.Now.Year - yearOfBirth;
        }
    }
}