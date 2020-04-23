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
        private readonly IPostDAO _postService;
        public DiscussionController()
        {
            _discussionService = new DiscussionService();
        }
        
        public ActionResult GetAllDiscussions()
        {
            IEnumerable<Discussion> discussions = _discussionService.GetAllDiscussions();
            return View("GetAllDiscussions", discussions);
        }

        public ActionResult Topic(int id)
        {
            var discussion = _discussionService.GetDiscussionID(id);

            //This lists posts under a specific discussion Id.
            var posts = discussion.Posts;

            return View();
            
        }

      
        }
    }
        
    
