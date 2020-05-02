using BookClub.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Community
{
    public class CommunityModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<ListofPosts> RecentPosts { get; set; }
    }
}