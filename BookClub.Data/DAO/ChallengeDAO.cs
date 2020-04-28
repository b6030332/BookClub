using BookClub.Data.IDAO;
using BookClub.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

         public Challenges GetChallenges()
        {
            //  string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            //  ApplicationUser currentUser = _context.Users.FirstOrDefault
            //  (x=> x.Id == currentUserId);

            //  return _context.Challenges.ToList().Where(x => x.User == currentUser);
            return _context.Challenges.Find();
        }
        public IEnumerable<Challenges> BuildChallengeTable()
        {
             string currentUserId = HttpContext.Current.User.Identity.GetUserId();
             ApplicationUser currentUser = _context.Users.FirstOrDefault
              (x => x.Id == currentUserId);

             return _context.Challenges.ToList().Where(x=> x.User == currentUser);

           // return _context.Challenges.ToList();
        }

        

    }
}

