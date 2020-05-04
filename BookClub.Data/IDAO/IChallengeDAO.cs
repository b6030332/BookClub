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

        IEnumerable<Challenges> GetMyChallenges();
        void AJAXAddChallenge(Challenges challenges, ApplicationUser User);

        void AddChallenge(Challenges challenges, ApplicationUser user);

        void EditChallenge(Challenges challenges);

        void DeleteChallenge(Challenges challenges);

        // void AJAXEditChallenge(int? id, bool value);


    }
}
