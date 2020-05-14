using BookClub.Data.IDAO;
using BookClub.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookClub.Data.DAO
{
    public class ChallengeDAO : IChallengeDAO
    {
        private ApplicationDbContext _context;
        public ChallengeDAO()
        {
            _context = new ApplicationDbContext();
        }
        public void AddChallenge(Challenges challenges, ApplicationUser user)
        {
            //Grab id of user that is logged in 
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            //Map it to column in database
            challenges.User = currentUser;

            //Add and save changes to database
            _context.Challenges.Add(challenges);
            _context.SaveChanges();
        }
        public void AJAXAddChallenge(Challenges challenges, ApplicationUser user)
        {
            //Grab id of user that is logged in 
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            challenges.User = currentUser;

            _context.Challenges.Add(challenges);
            _context.SaveChanges();
        }

        public IList<Challenges> GetChallenges()
        {
            //Grab id of user that is logged in 
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);
            return _context.Challenges.ToList();
        }

        public void EditChallenge(Challenges challenges)
        {
            _context.Entry(challenges).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteChallenge(int id, Challenges challenges)
        {
            //Find first or default challenge to delete
            var deleteChallenge = _context.Challenges.FirstOrDefault(c => c.Id == id);

            if (deleteChallenge != null)
            {
                _context.Challenges.Remove(deleteChallenge);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Challenges> GetMyChallenges()
        {
            //Grab id of user that is logged in 
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
             (x => x.Id == currentUserId);

            //Only show list of challenges which the user logged in has posted
            return _context.Challenges.ToList().Where(x => x.User == currentUser);
        }

        public Challenges GetChallenge(int id)
        {
            return _context.Challenges.Find(id);
        }

        public IEnumerable<Challenges> BuildChallengeTable()
        {
            //Grab id of user that is logged in 
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
             (x => x.Id == currentUserId);

            //Only show list of challenges which the user logged in has posted
            return _context.Challenges.ToList().Where(x => x.User == currentUser);
        }

        // public void AJAXEditChallenge(int? id, bool value)
        //  {
        //     Challenges challenges = _context.Challenges.Find(id);

        //    challenges.Completed = value;
        //    challenges.From = null;
        //    challenges.Until = null;

        //   _context.Entry(challenges).State = EntityState.Modified;
        //   _context.SaveChanges();

        //  }
    }

}

