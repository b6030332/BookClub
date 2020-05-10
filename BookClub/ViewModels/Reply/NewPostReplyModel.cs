using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.Reply
{
    public class NewPostReplyModel
    {
        public int Id { get; set; }
        public string ReplyContent { get; set; }
        public DateTime ReplyPosted { get; set; }
        public string ReplyUserId { get; set; }
        public string ReplyUserName { get; set; }

    }
}