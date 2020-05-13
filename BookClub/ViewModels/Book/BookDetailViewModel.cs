using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.Book
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookImage { get; set; }
        public long ISBN { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public string Format { get; set; }
        public string Blurb { get; set; }
        public int Year { get; set; }

        public int PostId { get; set; }
        public int DiscussionId { get; set; }
    
    }
}