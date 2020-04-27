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

        public void AddChallenge(Challenges challenges)
        {
           _dao.AddChallenge(challenges);
        }

        public IList<Challenges> GetChallenges()
        {
            return _dao.GetChallenges();
        }
    }
}
