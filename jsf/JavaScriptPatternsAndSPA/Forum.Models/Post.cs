using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Forum.Models
{
    public class Post
    {
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;

        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        public string Content { get; set; }

        //[ForeignKey("User")]
        //[Required(ErrorMessage = "User is required.")]
        //public User UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "PostDate is required.")]
        public DateTime PostDate { get; set; }

        public Post()
        {
            this.tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Tag> Tags
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
    }
}
