using BookClub.Models.Post;
using System.Collections.Generic;

namespace BookClub.Models.Discussion
{
    public class DiscussionTopicModel
    {
        public DiscussionListingModel Discussion { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
        
    }
}