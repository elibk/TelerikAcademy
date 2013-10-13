using MovieStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
using MovieStore.Entities;
using System.Data.Entity.Validation;

namespace MovieStore.Areas.Administration.Controllers
{
    //[Authorize()]
    public class MoviesController : Controller
    {
        MovieStoreContext context = new MovieStoreContext();
        
        // GET: /Administration/Movies/
        public ActionResult Index()
        {
            var moviesModels = context.Movies.Select(MovieModel.FromProductToProductModel);

            return View(moviesModels);
        }

        //
        // GET: /Administration/Movies/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Administration/Movies/Create
        public ActionResult CreateNewMovie()
        {
            ViewBag.MembersInMovie = context.MembersInMovies.OrderBy(x => x.Name).ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Studios = context.Studios.OrderBy(x => x.Name).ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return PartialView("_CreateNewMovie");
        }

        
        // POST: /Administration/Movies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var studioId = Convert.ToInt32(collection["Studio"]);
            var studio = context.Studios.Find(studioId);

            var directorId = Convert.ToInt32(collection["Director"]);
            var director = context.MembersInMovies.Find(directorId);

            var leadingMaleId = Convert.ToInt32(collection["LeadingMale"]);
            var leadingMale = context.MembersInMovies.Find(leadingMaleId);

            var leadingFemaleId = Convert.ToInt32(collection["LeadingFemale"]);
            var leadingFemale = context.MembersInMovies.Find(leadingFemaleId);

            if (studio == null)
	        {
		         ModelState.AddModelError("Studio", "Invalid studio.");
	        }

            if (director == null)
	        {
		         ModelState.AddModelError("Director", "Invalid director.");
	        }

            if (leadingMale == null)
	        {
		         ModelState.AddModelError("LeadinMale", "Invalid leading female role.");
	        }

            if (leadingFemale == null)
	        {
		         ModelState.AddModelError("LeadinFemale", "Invalid leading male role.");
	        }

            if (collection["Year"] != null)
            {
                
            }

            var year = Convert.ToInt32(collection["Year"]);

            var newMovie = new Movie()
            {
                Title = collection["Title"],
                Year = year,
                Studio = studio,
            };

            try
            {
                context.Movies.Add(newMovie);

                newMovie.ArtistsRoles.Add(new RoleInMovie() { Movie = newMovie, RoleType = RoleType.Director, MemberInMovie = director });
                newMovie.ArtistsRoles.Add(new RoleInMovie() { Movie = newMovie, RoleType = RoleType.LeadingFemale, MemberInMovie = leadingFemale });
                newMovie.ArtistsRoles.Add(new RoleInMovie() { Movie = newMovie, RoleType = RoleType.LeadingMale, MemberInMovie = leadingMale });
                if (ModelState.IsValid)
                {
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception ex)
            {
               

                DbEntityValidationException validationEx =
                   (DbEntityValidationException)ex;
                var errorMessages =
                    validationEx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                ModelState.AddModelError("EntityValidation", (String.Join("<br/>", errorMessages)));

                ViewBag.MembersInMovie = context.MembersInMovies.OrderBy(x => x.Name).ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ViewBag.Studios = context.Studios.OrderBy(x => x.Name).ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
               
            }

            return View("_CreateNewMovie");
        }

        //
        // GET: /Administration/Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administration/Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administration/Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administration/Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
