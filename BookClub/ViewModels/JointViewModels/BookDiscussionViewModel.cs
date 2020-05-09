using BookClub.Models.Book;
using BookClub.Models.Discussion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.JointViewModels
{
    public class BookDiscussionViewModel
    {
        public IEnumerable<ListofDiscussions> Discussions { get; set; }
        public NewBook Book { get; set; }
    }
}