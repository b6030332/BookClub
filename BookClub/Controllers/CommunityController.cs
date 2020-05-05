using BookClub.Data.IDAO;
using BookClub.Models.Community;
using BookClub.Models.Post;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IPostDAO _postService;
        public CommunityController()
        {
            _postService = new PostService();
        }

        // GET: Community
        public ActionResult Index()
        {
            //bring in custom view model 
            var model = BuildCommunityModel();
            return View(model);
        }

        private CommunityModel BuildCommunityModel()
        {
            //Get selection of recent posts
            var recentPosts = _postService.GetRecentPosts(10);
            
            //Map values of entity rows into new post model to display in custom view
            var posts = recentPosts.Select(post => new ListofPosts
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.ApplicationUser.UserName,
                AuthorId = post.ApplicationUser.Id,
                //AuthorRating = post.ApplicationUser.Rating,
                DatePosted = post.Created.ToString(),
                DiscussionId = post.Discussion.Id,
                DiscussionName = post.Discussion.Title,
                DiscussionDescription = post.Discussion.Description,
                RepliesCount = post.Replies.Count(),
                BookId = post.Discussion.Books.Id,
                BookImage = post.Discussion.Books.Image,
                BookTitle = post.Discussion.Books.Title

                
            });
            //return the new  model for community page 
            return new CommunityModel
            {
                RecentPosts = posts,
                SearchQuery = ""
            };
        }
    }
}