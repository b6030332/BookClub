using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Book
{
    public class NewBook
    {
        public int Id { get; set; }
        public string DiscussionName { get; set; }
        public int DiscussionId { get; set; }
        public string Author{ get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string Genre { get; set; }
        public string BookImage { get; set; }

    }
}