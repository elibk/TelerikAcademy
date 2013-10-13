namespace Exam.Data.Migrations
{
    using Exam.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
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

                var categories = new List<Category> 
                { 
                    new Category { Name = "Others"},
                    new Category { Name = "Web site bugs"},
                    new Category { Name = "UI bugs"},
                    new Category { Name = "Backend bugs"},
                    new Category { Name = "Data bugs"}
                };

                //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX UX_TagName ON Tags (Name)");
               
                var db = new ApplicationDbContext();

                var userAdmin = new ApplicationUser()
                {
                    UserName = "admin",
                    Logins = new Collection<UserLogin>()
                {
                    new UserLogin()
                    {
                        LoginProvider = "Local",
                        ProviderKey = "admin",
                    }
                },
                    Roles = new Collection<UserRole>()
                {
                    new UserRole()
                    {
                        Role = new Role("Admin")
                    }
                }
                    };

               

                context.Tickets.AddOrUpdate(
                 t => t.Description,
                    new Ticket 
                    {
                        Title="Data lost",
                        Description = "You lost all my messages! I'm going to sue you!!!!! ",
                        Author = userAdmin,
                        Category = categories [4], // data bugs
                        Priority = Priority.High,
                    },

                    new Ticket 
                    {
                        Title = "Ui sucks BIG TIME!",
                        Description = "The site UI is awful! I'm going to sue you!!!!! ",
                        Author = userAdmin,
                        Category = categories [2], // UI bugs
                        Priority = Priority.High,
                        UrlScreenshot ="http://i449.photobucket.com/albums/qq217/movh/158333d6.png"
                    },


                    new Ticket 
                    {
                        Title="Ui sucks",
                        Description = "The site UI like made by 6 year kid! I'm going to sue you!!!!! ",
                        Author = userAdmin,
                        Category = categories [2], // UI bugs
                        Priority = Priority.High,
                    },
                   

                     new Ticket 
                    {
                        Title = "I'm going to sue you! BIG TIME ",
                        Author = userAdmin,
                        Category = categories [0], // Others
                        Priority = Priority.High,
                        UrlScreenshot ="http://i449.photobucket.com/albums/qq217/movh/158333d6.png"
                    },

                      new Ticket 
                    {
                        Title = "Do you know how to spell! -> I'm going to sue you!!!!! ",
                        Author = userAdmin,
                        Category = categories [0], // Others
                        Priority = Priority.High,
                    },

                       new Ticket 
                    {
                        Title = "Just to say -> I'm going to sue you!!!!! ",
                        Author = userAdmin,
                        Category = categories [0], // Others
                        Priority = Priority.High,
                    },

                       new Ticket 
                    {
                        Title = "I'm going to sue you, motherfuckers!!",
                        Description = "I'm going to sue you, you sexy motherfucker!!!!! ",
                        Author = userAdmin,
                        Category = categories [0], // Others
                        Priority = Priority.High,
                    },

                        new Ticket 
                    {
                        Title = "I'm going to sue you!!!!! ",
                        Description = "You poor thing... I'm going to sue you!!!!! ",
                        Author = userAdmin,
                        Category = categories [0], // Others
                        Priority = Priority.High,
                    }
                );

                db.UserSecrets.Add(new UserSecret("admin",
                    "ACQbq83L/rsvlWq11Zor2jVtz2KAMcHNd6x1SN2EXHs7VuZPGaE8DhhnvtyO10Nf5Q=="));
               
                db.SaveChanges();
            }
        }
    }
}
