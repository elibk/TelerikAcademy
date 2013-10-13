using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBindingHomework
{
    public class Producer
    {
        public string Name { get; set; }

        private ICollection<string> models;

        public ICollection<string> Models
        {
            get { return models; }
            set { models = value; }
        }

        public Producer()
        {
            this.models = new HashSet<string>();
        }
    }
}