using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Reply
{
    public class NewPostReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }
    }
}