using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mustache.Services.Models
{
    public class Student
    {
        private IList<Mark> marks;

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

         [JsonProperty("lastName")]
        public string LastName { get; set; }

         [JsonProperty("grade")]
        public int Grade { get; set; }

         [JsonProperty("age")]
        public int Age { get; set; }


        
        public Student()
        {
            this.Marks = new List<Mark>();
        }

        [JsonProperty("marks")]
        public IList<Mark> Marks
        {
            get
            {
                return this.marks;
            }
            set
            {
                this.marks = value;
            }
        }
    }
}