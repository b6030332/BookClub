using BookClub.ViewModels.JointViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.ViewModels.AdminUsers
{
    public class AllUsersViewModel
    {
       public string UserId { get; set; }
       public IEnumerable<NewUserModel> AppUsers { get; set; }

       public IList<string> Rolesforthisuser { get; set; }
    }
}