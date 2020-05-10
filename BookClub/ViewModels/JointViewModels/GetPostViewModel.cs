using BookClub.ViewModels.Post;
using BookClub.ViewModels.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.JointViewModels
{
    public class GetPostViewModel
    {
        public IEnumerable<NewPostReplyModel> Replies { get; set; }
        public NewPostModel Posts { get; set; }
    }
}