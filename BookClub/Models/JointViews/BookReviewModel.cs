using BookClub.Models.Book;
using BookClub.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.JointViews
{
    public class BookReviewModel
    {
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
        public NewBook Book { get; set; }
    }
}