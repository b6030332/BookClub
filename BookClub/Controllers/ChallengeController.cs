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
        private readonly ApplicationDbContext _context;
        private readonly IBookDAO _bookService;
        private readonly IChallengeDAO _challengeService;
        //private readonly IPostDAO _postService;
        public ChallengeController()
        {
            _bookService = new BookService();
            _context = new ApplicationDbContext();
            _challengeService = new ChallengeService();
            
        }
        // GET: Challenge
        public ActionResult GetChallenges()
        {
            return View();
             // IEnumerable<Challenges> challenges = _challengeService.GetChallenges();
             //return View("GetChallenges", challenges);
        }

        private IEnumerable<Challenges> GetMyChallenges()
        {
            return _challengeService.BuildChallengeTable();
        }
      
        public ActionResult BuildChallengeTable()
        {
            IEnumerable<Challenges> challenges = _challengeService.BuildChallengeTable();
            return PartialView("_ChallengeTable", GetMyChallenges());
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXAddChallenge([Bind(Include = "Id,Description,From,Until")]Challenges challenges, ApplicationUser user)
        {
            if (ModelState.IsValid)
            {

                _challengeService.AddChallenge(challenges, user);
                challenges.Completed = false;
                challenges.From = null;
                challenges.Until = null;
                // return RedirectToAction("GetChallenges");
            }
            return PartialView("_ChallengeTable", GetMyChallenges());
        }
    }
}