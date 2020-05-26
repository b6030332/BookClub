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
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookClub.Controllers
{
    [Authorize(Roles = "Admin")]
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
            //if (userId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var applicationUser = _userService.GetAllApplicationUsers();

           // var user = _userManager.FindById(userId);
           // ViewBag.RoleNames = _userManager.GetRoles(user.Id);

            var userModel = applicationUser.Select(u => new NewUserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
              //  Rolesforthisuser = ViewBag.RoleNames = _userManager.GetRoles(user.Id)

            }).ToList();



            var model = new AllUsersViewModel()
            {

                AppUsers = userModel,
                //Rolesforthisuser = _userManager.GetRoles(User.Identity.GetUserId())

            };

            return View(model);

        }
       public async Task<ActionResult> UserDetails(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var user = await _userManager.FindByIdAsync(id);

            ViewBag.RoleNames = await _userManager.GetRolesAsync(user.Id);

            return View(user);
        }
        
        public ActionResult GetAllUsers()
        {
            return View(_context.Users.ToList());
        }
        public async Task<ActionResult> EditUser(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user.Id);

            return View(new EditUserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,

                RolesList = _roleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }
            
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> EditUser(EditUserViewModel model, params string[]  selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    return HttpNotFound();
                }

                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                var userRoles = await _userManager.GetRolesAsync(user.Id);

                selectedRole = selectedRole ?? new string[] { };

                var result = await _userManager.AddToRolesAsync(user.Id,
                    selectedRole.Except(userRoles).ToArray<string>()); 

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }

                result = await _userManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>()); // put to string

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }

                return RedirectToAction("GetAllUsers");

            }

            ModelState.AddModelError("", "Something's failed.");
            return View();


        }

        

        public ActionResult GetAllRoles()
        {
            return View(_context.Roles.ToList());
        }


        //method used to take string name id as an input parameter & attempts to find a role based on this Id
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = await _roleManager.FindByIdAsync(id);

            //get a list of users in this Role

            var users = new List<ApplicationUser>();

            //get the list of users in this role
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(model.RoleName);

                //attempts to create new role based on IdentityRole object
                var roleresult = await _roleManager.CreateAsync(role);

                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("GetAllRoles");
            }

            return View();
        }
        public async Task<ActionResult> EditRole(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            RoleViewModel model = new RoleViewModel { RoleId = role.Id, RoleName = role.Name };

            return View(model);
               
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                role.Name = model.RoleName;

                //updates role with any new property values assigned to it 
                await _roleManager.UpdateAsync(role);

                return RedirectToAction("GetAllRoles");
            }

            return View();
        }
        public async Task<ActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var role = await _roleManager.FindByIdAsync(id);

                if (role == null)
                {
                return HttpNotFound();
                }

            return View(role);
        }
        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var role = await _roleManager.FindByIdAsync(id);

                if (role == null)
                {
                    return HttpNotFound();
                }

                //take IdentityRole object as input parameter& then attempts to delete the role 
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }

                return RedirectToAction("GetAllRoles");
                
            }
            return View();

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

    }
}