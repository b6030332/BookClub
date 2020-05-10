using BookClub.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.Community
{
    public class CommunityViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<ListPostsModel> RecentPosts { get; set; }
    }
}