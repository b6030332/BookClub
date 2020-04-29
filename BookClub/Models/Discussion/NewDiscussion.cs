using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Discussion
{
    public class NewDiscussion
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string BookId { get; set; }
    }
}