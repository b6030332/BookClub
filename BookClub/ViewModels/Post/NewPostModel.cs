using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.Post
{
    public class NewPostModel
    {
        public int PostId { get; set; } 
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string DatePosted { get; set; }

        public int DiscussionId { get; set; }
        public string DiscussionName { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public int ReplyId { get; set; }

    
       

    


    }
}