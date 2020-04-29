using BookClub.Models.Book;
using BookClub.Models.Discussion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models
{
    public class BookDiscussionModel
    {
        public IEnumerable<ListofDiscussions> Discussions { get; set; }
        public NewBook Book { get; set; }
    }
}