using BookClub.Data;
using BookClub.Data.DAO;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Service.Service
{
    public class ChallengeService : IChallengeDAO
    {
        private IChallengeDAO _dao;
        public ChallengeService()
        {
            _dao = new ChallengeDAO();
        }

        public void AddChallenge(Challenges challenges, ApplicationUser user)
        {
           _dao.AddChallenge(challenges, user);
        }

        public IEnumerable<Challenges> BuildChallengeTable()
        {
           return _dao.BuildChallengeTable();
        }

        public void EditChallenge(Challenges challenges)
        {
            throw new NotImplementedException();
        }

        public Challenges GetChallenges()
        {
            return _dao.GetChallenges();
        }

    }
}
