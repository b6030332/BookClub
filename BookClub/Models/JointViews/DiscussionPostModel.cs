using BookClub.Models.Discussion;
using BookClub.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models
{
    public class DiscussionPostModel
    {
       public IEnumerable<ListofPosts> Posts { get; set; }
       public NewDiscussion Discussion { get; set; }
       public string SearchQuery { get; set; }
    }
}