
using RequireJS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RequireJS.Services.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        private readonly Student[] students = new Student[] 
            { 
                new Student()
                {
                     Id = 1, FirstName = "Pesho", LastName= "Peshev", Grade = 9, Marks = new List<Mark>()
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
                   Id = 2, FirstName = "Genko", LastName= "Matematika", Grade = 12, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.Math, Score = 55},
                    }
                },
                 new Student()
                {
                   Id = 3, FirstName = "Minka", LastName= "Praznikova", Grade = 6, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.Html, Score = 10},
                    }
                },
                 new Student()
                {
                   Id = 4, FirstName = "Anita", LastName= "Ivanova", Grade = 9, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.Css, Score = 25},
                        new Mark(){ Subject = SubjectName.JavaScript, Score = 23},
                        new Mark(){ Subject = SubjectName.Html, Score = 21},
                    }
                },
                 new Student()
                {
                  Id = 5,  FirstName = "Penka", LastName= "Pesheva", Grade = 12, Marks = new List<Mark>()
                    {
                        new Mark(){ Subject = SubjectName.CSharp, Score = 23},
                        new Mark(){ Subject = SubjectName.Math, Score = 5},
                        new Mark(){ Subject = SubjectName.Html, Score = 18},
                    }
                },
                 new Student()
                {
                   Id = 6,  FirstName = "Filip", LastName= "Filipov", Grade = 9
                } 
            };

        // GET api/students
        public IEnumerable<StudentSimple> Get()
        {
            return from s in this.students select new StudentSimple { FirstName = s.FirstName, Id = s.Id, Grade = s.Grade, LastName = s.LastName };
        }


        // GET api/students/{studentId}/marks
        [ActionName("marks")]
        public IEnumerable<Mark> GetMarks(int studentId)
        {
            return this.students.FirstOrDefault(s => s.Id == studentId).Marks;
        }
    }
}