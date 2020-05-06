using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Models.Profile;
using BookClub.Service.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookClub.Controllers
{
    public class ProfileController : Controller
    {
       
        private readonly IApplicationUserDAO _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ProfileController()
        {
            
            _userService = new ApplicationUserService();
            
        }
        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            //_userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
           
            
            _userManager = userManager;
          
        }

        // GET: Profile
        public ActionResult Detail(string id)   
        {
            var user = _userService.GetApplicationUser(id);

           // var userroles = _userManager.GetRolesAsync(user);

            
            var model = new ProfileModel()
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                MemberSince = user.MemberSince,
                IsAdmin = User.IsInRole("Admin"),
                IsMember = User.IsInRole("Member")

            };

            return View(model);
        }
    }
}