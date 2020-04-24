using BookClub.Data.IDAO;
using BookClub.Data.Models;

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
            
            IEnumerable<Post> posts = _discussionService.GetPostsByDiscussion(id);
            return View("GetPostsByDiscussion", posts);
           
        }
       
        }
    }
        
    
