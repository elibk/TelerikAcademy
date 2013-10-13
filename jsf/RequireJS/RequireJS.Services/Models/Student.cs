using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequireJS.Services.Models

{
    public class Student :StudentSimple
    {
        private IList<Mark> marks;

       
        
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