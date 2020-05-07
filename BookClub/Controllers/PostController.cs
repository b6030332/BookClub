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
        
        public PostController()
        {
            _postService = new PostService();
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
            Post post = _postService.GetPost(id);
            return View();
        }
        [HttpPost]
        public ActionResult DeletePost(int id, NewPost model)
        {
            try
            {
                Post post = new Post();
                post.Title = model.Title;
                post.Content = model.Content;
                post.Created = DateTime.Now;

                _postService.DeletePost(post);

                

                return RedirectToAction("GetPost", "Post", new { id = post.Id });
            }
            catch
            {
                return View();
            }
        }



    }
}