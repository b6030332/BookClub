using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Discussion
{
    public class ListofDiscussions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookBlurb { get; set; }
        public string BookImage { get; set; }

        

        

    }
}