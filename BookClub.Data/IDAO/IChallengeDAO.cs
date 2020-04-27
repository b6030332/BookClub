using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.IDAO
{
    public interface IChallengeDAO
    {
        IList<Challenges> GetChallenges();

        void AddChallenge(Challenges challenges, ApplicationUser user);
    }
}
