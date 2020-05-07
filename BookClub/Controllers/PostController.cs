using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models.Post;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostDAO _postService;
        private readonly IReplyDAO _replyService;
        public PostController()
        {
            _postService = new PostService();
            _replyService = new ReplyService();
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
        [HttpGet]
        public ActionResult DeleteReply(int id)
        {
            
            return View( _replyService.GetReply(id));
        }
        [HttpPost]
        public ActionResult DeleteReply(int id, PostReply reply)
        {

                var replies = new PostReply();
            
                _replyService.DeleteReply(id, reply);

                return RedirectToAction("GetPost", "Post", new { id = reply.Id });
        }
           



    }
}