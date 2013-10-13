using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Services.Models
{
    public class PostDetails : PostModel
    {
        private IEnumerable<CommentModel> comments;


       [JsonProperty("postedBy")]
       public string CreatedBy { get; set; }

        [JsonProperty("postDate")]
       public DateTime PostDate { get; set; }

       public PostDetails()
           :base()
        {
            this.comments = new HashSet<CommentModel>();
        }

         [JsonProperty("comments")]
        public virtual IEnumerable<CommentModel> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}