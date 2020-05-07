using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        }

        public IEnumerable<Challenges> GetMyChallenges()
        {
            IEnumerable<Challenges> myChallenges = _challengeService.GetMyChallenges();

            int completeCount = 0;
            foreach (Challenges challenges in myChallenges)
            {
                if (challenges.Completed)
                {
                    completeCount++;
                }
            }
            ViewBag.Percent = Math.Round(100f * ((float)completeCount / (float)myChallenges.Count()));

            return myChallenges;

        }

        public ActionResult BuildChallengeTable()
        {
            return PartialView("_ChallengeTable", GetMyChallenges());
        }

        public ActionResult AddChallenge()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddChallenge([Bind(Include = "Id,Description")]Challenges challenges, ApplicationUser user)
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
        public ActionResult AJAXAddChallenge([Bind(Include = "Id,Description")]Challenges challenges, ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                _challengeService.AJAXAddChallenge(challenges, user);
                challenges.Completed = false;
                challenges.From = null;
                challenges.Until = null;
                // return RedirectToAction("GetChallenges");
            }
            return PartialView("_ChallengeTable", GetMyChallenges());
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult EditChallenge(Challenges challenges)
        {
            if (ModelState.IsValid)
            {
                _challengeService.EditChallenge(challenges);
                return RedirectToAction("GetChallenges");
            }
            return View(challenges);
        }
        [HttpPost]
        public ActionResult AJAXEditChallenge(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Challenges challenges = _context.Challenges.Find(id);
            if (challenges == null)
            {
                return HttpNotFound();
            }
            else
            {
                challenges.Completed = value;
                challenges.From = null;
                challenges.Until = null;
                _context.Entry(challenges).State = EntityState.Modified;
                _context.SaveChanges();

                return PartialView("_ChallengeTable", GetMyChallenges());
            }
        }

        // [HttpPost]
        // public ActionResult AJAXEditChallenge(int? id, bool value)
        // {
        //    if (id == null)
        //    {
        //       return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //   }
        //   _challengeService.AJAXEditChallenge(id, value);
        //  if (_challengeService == null)
        //  {
        //     return HttpNotFound();
        // }

        //  return PartialView("_ChallengeTable", GetMyChallenges());

        //  }

        [HttpGet]
        public ActionResult DeleteChallenge(int id)
        {

            return View(_challengeService.GetChallenge(id));
        }
        [HttpPost]
        public ActionResult DeleteChallenge(int id, Challenges challenges)

        {
            var _challenges = new Challenges();

            _challengeService.DeleteChallenge(id, challenges);
            return RedirectToAction("GetChallenges", "Challenge", new { id = challenges.Id });
        }
        
    }
}
    
    
