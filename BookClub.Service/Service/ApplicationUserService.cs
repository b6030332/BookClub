using BookClub.Data;
using BookClub.Data.DAO;
using BookClub.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Service.Service
{
    public class ApplicationUserService : IApplicationUserDAO
    {
        private IApplicationUserDAO _dao;

        public ApplicationUserService()
        {
            _dao = new ApplicationUserDAO();
        }

        public IEnumerable<ApplicationUser> GetAllApplicationUsers()
        {
            return _dao.GetAllApplicationUsers();
        }

        public ApplicationUser GetApplicationUser(string id)
        {
            return _dao.GetApplicationUser(id);
        }
    }
}
