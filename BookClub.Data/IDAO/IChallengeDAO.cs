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
        Challenges GetChallenges();

        IEnumerable<Challenges> BuildChallengeTable();

        void AddChallenge(Challenges challenges, ApplicationUser user);

        void EditChallenge(Challenges challenges);

        // void AJAXEditChallenge(int? id, bool value);


    }
}
