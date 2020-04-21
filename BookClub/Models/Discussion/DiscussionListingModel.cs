using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Discussion
{
    public class DiscussionListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int BookId { get; set; }
       
    
    }
}