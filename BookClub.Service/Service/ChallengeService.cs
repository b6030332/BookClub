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
        public void AJAXAddChallenge(Challenges challenges, ApplicationUser user)
        {
            _dao.AJAXAddChallenge(challenges, user);
        }

        // public void AJAXEditChallenge(int? id, bool value)
        // {
        //    _dao.AJAXEditChallenge(id, value);
        // }

        //public IEnumerable<Challenges> BuildChallengeTable()
        //{
        //    return _dao.BuildChallengeTable();
        //}

        public void DeleteChallenge(int id, Challenges challenges)
        {
            _dao.DeleteChallenge(id, challenges);
        }

        public void EditChallenge(Challenges challenges)
        {
            _dao.EditChallenge(challenges);
        }

        public Challenges GetChallenge(int id)
        {
            return _dao.GetChallenge(id);
        }

        public IList<Challenges> GetChallenges()
        {
            return _dao.GetChallenges();
        }
        public IEnumerable<Challenges> GetMyChallenges()
        {
            return _dao.GetChallenges();
        }
        
    }
}