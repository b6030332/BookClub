using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using BookClub.ViewModels.Post;
using System;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostDAO _postService;
        private readonly IReplyDAO _replyService;
        private readonly IDiscussionDAO _discussionService;
        public PostController()
        {
            _postService = new PostService();
            _replyService = new ReplyService();
            _discussionService = new DiscussionService();
        }
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPost(int id)
        {
            Post post = _postService.GetPost(id);
            return View("GetPost", post);
        }
        [HttpGet]
        public ActionResult AddPost(int id)
        {
            //Find the id of discussion we're posting in 
            var discussion = _discussionService.GetDiscussionID(id);

            AddPostViewModel addPost = new AddPostViewModel();
            addPost.DicussionName = discussion.Title;

            return View(addPost);
        }
        [HttpPost]
        public ActionResult AddPost(AddPostViewModel model, Discussion discussion)
        {
            //Map the new post values for NewPost model to be pushed into database

            if (ModelState.IsValid)
            {
                var post = new Post();
                post.Title = model.Title;
                post.Content = model.Content;
                post.Created = DateTime.Now;

                //logic for adding post with user and discussion id is processed in the POSTDAO 

                _postService.AddPost(post, discussion);
                return RedirectToAction("GetPost", "Post", new { id = post.Id });
            }
            return View(model);

        }
        [HttpGet]
        public ActionResult DeletePost(int id)
        {
           
            return View(_postService.GetPost(id));
        }
        [HttpPost]
        public ActionResult DeletePost(int id, Post post)
        {   
                var posts = new Post();
              
                _postService.DeletePost(id, post);
                
                return RedirectToAction("GetPostsByDiscussion", "Discussion", new { id = post.Id });
            
        }
        public ActionResult AjaxPost(int id)
        {
            Post post = _postService.AjaxPost(id);
            return View("GetPost", post);
           // return View();
        }
        public ActionResult BuildPostTable()
        {
            return PartialView("_postTable", BuildPostTable());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXAddReply([Bind(Include = "Id,Content,Created")]PostReply replies)
        {
            if (ModelState.IsValid)
            {
                //PostReply reply = new PostReply();
                
                replies.Created = DateTime.Now;


                _postService.AJAXAddReply(replies);
                
                // return RedirectToAction("GetChallenges");
            }
            return PartialView("_ChallengeTable", BuildPostTable());
        }




    }
}