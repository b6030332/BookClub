using BookClub.Data;
using BookClub.Data.DAO;
using BookClub.Data.IDAO;
using BookClub.Models.ApplicationUser;
using BookClub.Service.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IApplicationUserDAO _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _applicationUserService = new ApplicationUserService();
            _userManager = userManager;
        }

        // GET: UserProfile
        public ActionResult Detail(string id)
        {
            var user = _applicationUserService.GetApplicationUser(id);
            
            var model = new ProfileModel()
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                MemberSince = user.MemberSince,
                IsAdmin = User.IsInRole("Admin")

            };

            return View(model);
        }
    }
}