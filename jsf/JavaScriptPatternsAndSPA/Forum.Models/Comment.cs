using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Forum.Models
{
   public class Comment
    {
       public int Id { get; set; }

       [Required(ErrorMessage = "Text is required.")]
       public string Text { get; set; }

       [Required(ErrorMessage = "User is required.")]
       public User User { get; set; }

       [Required(ErrorMessage = "Post is required.")]
       public Post Post { get; set; }

       [Required(ErrorMessage = "PostDate is required.")]
       public DateTime PostDate { get; set; }

    }
}
