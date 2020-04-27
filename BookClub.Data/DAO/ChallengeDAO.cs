using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.DAO
{
    public class ChallengeDAO : IChallengeDAO
    {
        private ApplicationDbContext _context;
        public ChallengeDAO()
        {
            _context = new ApplicationDbContext();
        }
        public void AddChallenge(Challenges challenges)
        {
            _context.Challenges.Add(challenges);
            _context.SaveChanges();
        }

            public IList<Challenges> GetChallenges()
        {
            return _context.Challenges.ToList();
        }
    }
}

