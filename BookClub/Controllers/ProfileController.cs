using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Models.Profile;
using BookClub.Service.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            // var userroles = _userManager.GetRolesAsync(user).Result;


            var model = new ProfileModel()
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                ProfileImageUrl = user.ProfileImage,

                IsAdmin = User.IsInRole("Admin"),
                IsMember = User.IsInRole("Member")

            };

            return View(model);
        }


        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(ProfileModel model)
        {
            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(model.ImageFile.FileName);

            //Add Current Date To Attached File Name  
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            string UploadPath = ConfigurationManager.AppSettings["ProfileImageUrl"].ToString();

            //Its Create complete path to store in server.  
            model.ProfileImageUrl = UploadPath + FileName;

            //To copy and save file into server.  
            model.ImageFile.SaveAs(model.ProfileImageUrl);

            return View();
        }
    }
}

    