using BookClub.Data;
using BookClub.Data.DAO;
using BookClub.Data.IDAO;
using BookClub.Service.Service;
using BookClub.ViewModels.AdminUsers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookClub.Controllers
{
    public class UserAdminController : Controller
    {
        private ApplicationDbContext _context;
        private IApplicationUserDAO _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserAdminController()
        {
            _userService = new ApplicationUserService();
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
        }
        public ActionResult GetAllApplicationUsers(string userId)
        {
            var applicationUser = _userService.GetAllApplicationUsers();
            //  string[] userId = _userManager.Users.Where(u => u.Id == Id)
            //      .FirstOrDefault();

            //var userManager = _userManager.FindByIdAsync(userId);
                    
            //var role = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            var userModel = applicationUser.Select(u => new NewUserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                //Rolesforthisuser = _userManager.GetRoles(userId)

            }).ToList();

            var model = new AllUsersViewModel()
            {

                AppUsers = userModel,
                //Rolesforthisuser = _userManager.GetRoles(User.Identity.GetUserId())

            };

            return View(model);

        }
        public ActionResult GetUserRole_(string userId)
        {
            ViewBag.UserId = userId;

            var userManager = _userManager.FindByIdAsync(userId);

            var model = new List<NewUserModel>();

            foreach (var role in _roleManager.Roles)
            {
                var newUserModel = new NewUserModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
            }

            return View(model);

            }
        // GET: UserAdmin
        public ActionResult GetAllUsers()
        {
            return View(_context.Users.ToList());
        }
        public ActionResult GetAllRoles()
        {
            return View(_context.Roles.ToList());
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            try
            {
                IdentityRole role = new IdentityRole();

                role.Name = collection["RoleName"];
                _context.Roles.Add(role);
                _context.SaveChanges();
                return RedirectToAction("GetRoles");

            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName,
                StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            var roleList = _context.Roles.OrderBy(r => r.Name).ToList()
            .Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            var userList = _context.Users
            .OrderBy(u => u.UserName).ToList()
            .Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View("ManageUserRoles");

        }
        [HttpGet]
        public ActionResult GetRolesforUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRolesforUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals
                (UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);

            }

            return View("GetRolesforUserConfirmed");
        }
        [HttpGet]
        public async Task<ActionResult> ManageRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach(var role in _roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user.ToString(), role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                
                }
                model.Add(userRolesViewModel);
            }

            return View(model);
        }

    }
}