using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MovieStore.Models
{
    public class MemberInMovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static Expression<Func<MemberInMovie, MemberInMovieModel>> FromMemeberInMovie
        {
            get
            {
                return x => new MemberInMovieModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                  
                };
            }
        }
    }
}