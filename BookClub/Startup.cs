using BookClub.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookClub.Startup))]
namespace BookClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
       
        //method to create default User Roles and Admin User for login
        private void createRolesandUsers()
        {
            ApplicationDbContext _context = new ApplicationDbContext();

           var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
           var _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));


            //create default admin role if it doesn't exist
            if (_roleManager.RoleExists("Admin"))
            {

                //first create Admin Role
                var role = new IdentityRole();
                role.Name = "Admin";
                _roleManager.Create(role);


                //Here create Admin Super User

                var user = new ApplicationUser();
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.UserName = "Admin";
                user.Email = "admin@admin.com";


                string userPwd = "Wright12!";

                var checkUser = _userManager.Create(user, userPwd);

                //add default User to Admin Role
                if (checkUser.Succeeded)
                {
                    var result = _userManager.AddToRole(user.Id, "Admin");
                }

                //create Member role

                if (!_roleManager.RoleExists("Member"))
                {
                    var memberRole = new IdentityRole();

                    role.Name = "Member";
                    _roleManager.Create(memberRole);
                }
            }


        }

        
    }
}
