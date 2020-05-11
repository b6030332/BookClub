using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.AdminUsers
{
    public class NewUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        //public IList<string> Rolesforthisuser { get; set; }

    }
}