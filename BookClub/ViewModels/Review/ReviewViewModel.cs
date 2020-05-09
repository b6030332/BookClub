using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.Review
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string UserId { get; set; }
        public string AuthorName { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public string DateCreated { get; set; }
    }
}