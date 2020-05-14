using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.Post
{
    public class AddPostViewModel
    {
        [Required]
        [Display(Name = "Post Subject")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Post Content")]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public string DicussionName { get; set; }

        public int DiscussionId { get; set; }
       
    }
}