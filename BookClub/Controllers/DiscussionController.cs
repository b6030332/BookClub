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

      
        public ActionResult GetPostsByDiscussion(int id)
        {
            var discussion = _discussionService.GetDiscussionID(id);

            var posts = discussion.Posts;

            //var posts = new List<Post>();

            //if(!String.IsNullOrEmpty(searchQuery))
            //{
            //    posts = _discussionService.GetSearchedPosts(id, searchQuery).ToList();
            //}
            // posts = discussion.Posts.ToList();

            //Map values given in new model to respective values in raw entities
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

            //Use custom model to grab a collection of the "ListofPosts" model & use NewDiscussion model from earlier to map values
            var model = new DiscussionPostModel
            {
                //Map values given in custom models
                Posts = listofPosts,
                Discussion = BuildNewDiscussion(discussion)

            };

            //return the model to be accessed in viewpage
            return View(model);
        }

        
        private NewDiscussion BuildNewDiscussion(Discussion discussion)
        {
            //Map values in NewDiscussion model to raw Discussion entity
            return new NewDiscussion
            {
               Id = discussion.Id,
                Title = discussion.Title,
                Content = discussion.Description,
            };
        }

        //[HttpPost]
        //public ActionResult Search(int id, string searchQuery)
        //{
        //    var discussion = _discussionService.GetDiscussionID(id);

        //    return RedirectToAction("GetPostsByDiscussion", new { id, searchQuery });
        //}
    }

}
    
        
    
