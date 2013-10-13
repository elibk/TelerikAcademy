using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Services.Models
{
    public class PostModel
    {
         [JsonProperty("id")]
        public int Id { get; set; }

         [JsonProperty("title")]
        public string Title { get; set; }

         [JsonProperty("content")]
        public string Content { get; set; }

         
        private IEnumerable<string> tags;

        public PostModel()
        {
            this.tags = new HashSet<string>();
        }

        [JsonProperty("tags")]
        public virtual IEnumerable<string> Tags
        {
            get
            {
                return this.tags;
            }
            set
            {
                this.tags = value;
            }
        }
    }
}