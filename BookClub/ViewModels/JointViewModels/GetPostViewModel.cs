using BookClub.Data.Models;
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

        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string DatePosted { get; set; }

        public int DiscussionId { get; set; }
        public string DiscussionName { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        
        public IEnumerable<NewPostReplyModel> Replies { get; set; }
        
    }
}