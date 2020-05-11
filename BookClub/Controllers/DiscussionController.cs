using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using BookClub.ViewModels.Discussion;
using BookClub.ViewModels.JointViewModels;
using BookClub.ViewModels.Post;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookClub.Controllers
{

    public class DiscussionController : Controller
    {
        private readonly IDiscussionDAO _discussionService;
        private ApplicationDbContext _context;
        //private readonly IPostDAO _postService;
       
        public DiscussionController()
        {
            _context = new ApplicationDbContext();
            _discussionService = new DiscussionService();
        }
        
        public ActionResult GetAllDiscussions()
        {
            IEnumerable<Discussion> discussions = _discussionService.GetAllDiscussions();
            return View("GetAllDiscussions", discussions);
        }
        
        public ActionResult GetPostsByDiscussion(int id, string searchQuery)
        {
            var discussion = _discussionService.GetDiscussionID(id);
            //var posts = new List<Post>();

            // posts = _discussionService.GetSearchedPosts(discussion, searchQuery).ToList();
           

            var posts = discussion.Posts;

            //var posts = new List<Post>();

            //if(!String.IsNullOrEmpty(searchQuery))
            //{
            //    posts = _discussionService.GetSearchedPosts(id, searchQuery).ToList();
            //}
            // posts = discussion.Posts.ToList();

            //Map values given in new model to respective values in raw entities
            var listofPosts = posts.Select(post => new ListPostsModel
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
            var model = new DiscussionPostViewModel
            {
                //Map values given in custom models
                Posts = listofPosts,
                Discussion = BuildNewDiscussion(discussion)

            };

            //return the model to be accessed in viewpage
            //return View(model);
            return View(model);
        }

        
        private NewDiscussionModel BuildNewDiscussion(Discussion discussion)
        {

            //Map values in NewDiscussion model to raw Discussion entity
            return new NewDiscussionModel
            {
               Id = discussion.Id,
               Title = discussion.Title,
               Content = discussion.Description,
            };
        }

        
    }

}
    
        
    
