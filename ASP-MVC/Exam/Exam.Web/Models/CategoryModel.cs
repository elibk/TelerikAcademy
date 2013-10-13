using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

       [Required]
        public string Name { get; set; }

        public static Expression<Func<Category, CategoryModel>> FromCategory
        {
            get
            {
                return x => new CategoryModel()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name
                };
            }
        }
    }
}