using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class User
    {
        private ICollection<Post> posts;
        private ICollection<Comment> comments;

        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 6, ErrorMessage =
            "UserName must be between 6 and 30 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'''.''''_''\s]{1,40}$", ErrorMessage =
         "Numbers and special characters are not allowed in the name.")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

       
        [StringLength(30, MinimumLength = 6, ErrorMessage =
            "DisplayName must be between 6 and 30 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'''.''''_''\s]{1,40}$", ErrorMessage =
        "Numbers and special characters are not allowed in the name.")]
        [Required(ErrorMessage = "DisplayName is required.")]
        public string DisplayName { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "AuthCode is required.")]
        public string AuthCode { get; set; }

        [StringLength(40)] 
        public string SessionKey { get; set; }

        public User()
        {
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();

        }

        public virtual ICollection<Comment> Comments
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

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }
            set
            {
                this.posts = value;
            }
        }
    }
}
