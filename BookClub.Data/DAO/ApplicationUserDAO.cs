using BookClub.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.DAO
{
    public class ApplicationUserDAO : IApplicationUserDAO
    {
        private ApplicationDbContext _context;

        public ApplicationUserDAO()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ApplicationUser> GetAllApplicationUsers()
        {
            return _context.Users;
        }

        public ApplicationUser GetApplicationUser(string id)
        {
            return _context.Users.Find(id);
        }
    }
}
