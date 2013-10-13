using Mustache.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Mustache.Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        // GET api/students
        public IEnumerable<Student> Get()
        {
            return new Student[] 
            { 
                new Student()
                {
                    FirstName = "Pesho", LastName= "Peshev", Age= 15, Grade = 9, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.CSharp, Score = 11},
                        new Mark(){ Subject = SubjectName.Css, Score = 13},
                        new Mark(){ Subject = SubjectName.JavaScript, Score = 23},
                        new Mark(){ Subject = SubjectName.Math, Score = 12},
                        new Mark(){ Subject = SubjectName.Html, Score = 5},
                    }
                },
                 new Student()
                {
                    FirstName = "Genko", LastName= "Matematika", Age= 21, Grade = 12, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.Math, Score = 55},
                    }
                },
                 new Student()
                {
                    FirstName = "Minka", LastName= "Praznikova", Age= 12, Grade = 6, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.Html, Score = 10},
                    }
                },
                 new Student()
                {
                    FirstName = "Anita", LastName= "Ivanova", Age= 16, Grade = 9, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.Css, Score = 25},
                        new Mark(){ Subject = SubjectName.JavaScript, Score = 23},
                        new Mark(){ Subject = SubjectName.Html, Score = 21},
                    }
                },
                 new Student()
                {
                    FirstName = "Penka", LastName= "Pesheva", Age= 18, Grade = 12, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.CSharp, Score = 23},
                        new Mark(){ Subject = SubjectName.Math, Score = 5},
                        new Mark(){ Subject = SubjectName.Html, Score = 18},
                    }
                },
                 new Student()
                {
                    FirstName = "Filip", LastName= "Filipov", Age= 15, Grade = 9
                } 
            };
        }
    }
}