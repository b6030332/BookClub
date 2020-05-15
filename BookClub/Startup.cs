using BookClub.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Web;

[assembly: OwinStartupAttribute(typeof(BookClub.Startup))]
namespace BookClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public static void InitializeIdentityForEF(ApplicationDbContext _context)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

           // const string username = "admin@admin.com";

            const string name = "admin@admin.com";

            const string password = "admin12@admin.com";

            const string roleName = "Admin";

            //Create Role Admin if it does not exist    

            var role = roleManager.FindByName(roleName);

            if (role == null)

            {

                role = new IdentityRole(roleName);

                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = name,
                    Email = name,
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                var result = userManager.Create(user, password);

                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added    

            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role.Name))

            {

                var result = userManager.AddToRole(user.Id, role.Name);

            }

            //Create Member role                  

            const string userRoleName = "Member";

            role = roleManager.FindByName(userRoleName);

            if (role == null)

            {

                role = new IdentityRole(userRoleName);

                var roleresult = roleManager.Create(role);
            }
            _context.SaveChanges();
           
        }
        
    }
        
    }

