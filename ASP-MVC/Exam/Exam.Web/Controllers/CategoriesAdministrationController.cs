using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Exam.Web.Models;
using Exam.Models;


namespace Exam.Web.Controllers
{
     [Authorize(Roles = "Admin")]
    public class CategoriesAdministrationController : BaseController
    {
         
        public ActionResult Index()
        {
            return View(this.Data.Categories.All().Select(CategoryModel.FromCategory).ToList());
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var categories = this.Data.Categories.All().Select(CategoryModel.FromCategory);

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category();
                newCategory.Name = category.Name;

                this.Data.Categories.Add(newCategory);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.Data.Categories.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoryModel model = new CategoryModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                
            };

            return View(model);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                var editCategory = this.Data.Categories.GetById(category.CategoryId);
                editCategory.Name = category.Name;
                

                this.Data.Categories.Update(editCategory);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.Data.Categories.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoryModel model = new CategoryModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var questionsToThisCat = this.Data.Tickets.All().Where(t => t.CategoryId == id).ToList();

            foreach (var item in questionsToThisCat)
            {
                this.Data.Tickets.Delete(item);
                var questionComments = this.Data.Comments.All().Where(t => t.Ticket.TicketId == item.TicketId).ToList();
                foreach (var comment in questionComments)
                {
                    this.Data.Comments.Delete(comment);
                }
            }

            this.Data.Categories.Delete(id);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
