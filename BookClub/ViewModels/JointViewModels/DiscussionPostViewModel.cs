using BookClub.ViewModels.Discussion;
using BookClub.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.JointViewModels
{
    public class DiscussionPostViewModel
    {
        public IEnumerable<ListPostsModel> Posts { get; set; }
        public NewDiscussionModel Discussion { get; set; }
       
    }
}