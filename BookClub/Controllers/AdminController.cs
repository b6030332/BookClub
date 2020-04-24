using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class AdminController : Controller
    {
        private IPostDAO _postService;
        private IDiscussionDAO _discussionService;

        private static UserManager<ApplicationUser> _userManager;
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _postService = new PostService();
            _discussionService = new DiscussionService();
            
        }
        [HttpGet]
        public ActionResult AddPost()
        {
            
            return View();
        }
      //  [HttpPost]
      //  public async Task<ActionResult> AddPost(Post post)
      //  {
      //      var UserId = HttpContext.User.Identity.GetUserId();
      //      var user = await _userManager.FindByIdAsync(UserId);
          
      //      await _postService.AddPost(post);

      //      return RedirectToAction("GetPost", "Post", post.Id);
      //  }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}