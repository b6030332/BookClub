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
    public class ChallengeController : Controller
    {
        private readonly IChallengeDAO _challengeService;
        //private readonly IPostDAO _postService;
        public ChallengeController()
        {
            _challengeService = new ChallengeService();
        }
        // GET: Challenge
        public ActionResult GetChallenges()
        {
            IList<Challenges> challenges = _challengeService.GetChallenges();
            return View("GetChallenges", challenges);
        }
    }
}