using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Reply
{
    public class ListofPostReply
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public bool IsAuthorAdmin { get; set; }

        public DateTime Created { get; set; }
        public string ReplyContent { get; set; }
        
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        public string DiscussionName { get; set; }
        public int DiscussionId { get; set; }


    }
}