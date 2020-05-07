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
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            challenges.User = currentUser;

            _context.Challenges.Add(challenges);
            _context.SaveChanges();
        }
        public void AJAXAddChallenge(Challenges challenges, ApplicationUser user)
        {
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            challenges.User = currentUser;

            _context.Challenges.Add(challenges);
            _context.SaveChanges();
        }

        public IList<Challenges> GetChallenges()
        {
            return _context.Challenges.ToList();
        }

        public void EditChallenge(Challenges challenges)
        {
            _context.Entry(challenges).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteChallenge(int id, Challenges challenges)
        {
            var deleteChallenge = _context.Challenges.FirstOrDefault(c => c.Id == id);

            if (deleteChallenge != null)
            {
                _context.Challenges.Remove(deleteChallenge);
                _context.SaveChanges();
            }
            
            
        }

        public IEnumerable<Challenges> GetMyChallenges()
        {
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
             (x => x.Id == currentUserId);

            return _context.Challenges.ToList().Where(x => x.User == currentUser);
        }

        public Challenges GetChallenge(int id)
        {
            return _context.Challenges.Find(id);
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

