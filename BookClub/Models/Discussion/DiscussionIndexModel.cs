using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Discussion
{
    public class DiscussionIndexModel
    {
       public IEnumerable<DiscussionListingModel> DiscussionList { get; set; }
    }
}