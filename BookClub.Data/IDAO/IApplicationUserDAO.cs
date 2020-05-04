using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.IDAO
{
    public interface IApplicationUserDAO
    {
        ApplicationUser GetApplicationUser(int id);
        IEnumerable<ApplicationUser> GetAllApplicationUsers();
    }
}
