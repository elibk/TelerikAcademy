using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Services.Models
{
   public class CommentModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("commentedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("postDate")]
        public DateTime PostDate { get; set; }
    }
}
