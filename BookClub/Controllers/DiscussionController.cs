using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models;
using BookClub.Models.Discussion;
using BookClub.Models.Post;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    
    public class DiscussionController : Controller
    {
        private readonly IDiscussionDAO _discussionService;
        //private readonly IPostDAO _postService;
        public DiscussionController()
        {
            _discussionService = new DiscussionService();
        }
        
        public ActionResult GetAllDiscussions()
        {
            IEnumerable<Discussion> discussions = _discussionService.GetAllDiscussions();
            return View("GetAllDiscussions", discussions);
        }

      //  public ActionResult GetPostsByDiscussion(int id)
      // {
      //      IEnumerable<Post> posts = _discussionService.GetPostsByDiscussion(id);
      //      return View("GetPostsByDiscussion", posts);
      //  }
        public ActionResult GetD(int id)
        {
            var discussion = _discussionService.GetDiscussionID(id);
            
            var posts = discussion.Posts;

            var listofPosts = posts.Select(post => new ListofPosts
            {
                Id = post.Id,
                AuthorId = post.ApplicationUser.Id,
                AuthorName = post.ApplicationUser.UserName,
                AuthorRating = post.ApplicationUser.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                DiscussionId = post.Discussion.Id,
                DiscussionName = post.Discussion.Title,
                DiscussionDescription = post.Discussion.Description,
                
            });

            var model = new DiscussionPostModel
            {
                Posts = listofPosts,
                Discussion = BuildNewDiscussion(discussion)

            };

            return View(model);
        }

        private NewDiscussion BuildNewDiscussion(Discussion discussion)
        {
            return new NewDiscussion
            {
                Id = discussion.Id,
                Title = discussion.Title,
                Content = discussion.Description,
            };
        }
    }

}
    
        
    
