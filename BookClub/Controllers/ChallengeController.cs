using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class ChallengeController : Controller
    {
        
        private readonly IBookDAO _bookService;
        private readonly IChallengeDAO _challengeService;
        //private readonly IPostDAO _postService;
        public ChallengeController()
        {
            _bookService = new BookService();
            
            _challengeService = new ChallengeService();
            
        }
        // GET: Challenge
        public ActionResult GetChallenges()
        {
            IList<Challenges> challenges = _challengeService.GetChallenges();
            return View("GetChallenges", challenges);
        }
        
        public ActionResult AddChallenge()
        {
          
            return View();
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult AddChallenge([Bind(Include ="Id,Description,Completed,From,Until")]Challenges challenges, ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                
                _challengeService.AddChallenge(challenges, user);
                return RedirectToAction("GetChallenges");
            } 
            return View(challenges);
        }
    }
}