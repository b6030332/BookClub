using BookClub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Post
{
    public class NewPost
    {
        public string DiscussionName { get; set; }
        public int DiscussionId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        
    }
}