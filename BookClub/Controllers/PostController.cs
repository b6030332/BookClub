using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BookClub.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BookClub.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostDAO _postService;
        private readonly IDiscussionDAO _discussionService;
        private static UserManager<ApplicationUser> _userManager;

        public PostController()
        {
            _postService = new PostService();
            _discussionService = new DiscussionService();
        }
        // GET: Post
        public ActionResult GetPost(int id)
        {
            Post post = _postService.GetPost(id);
            return View("GetPost", post);
        }
        
       
        
    }
}