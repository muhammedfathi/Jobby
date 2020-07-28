using Jobby.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jobby.Startup))]
namespace Jobby
{
    public partial class Startup
    {
        private ApplicationDbContext db=new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DefaultAdminAndUser();
        }

        public void DefaultAdminAndUser()
        {
            var rolemanger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermangaer = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            
            IdentityRole role = new IdentityRole();

            if (!rolemanger.RoleExists("Admins"))
            {
                role.Name = "Admins";
                rolemanger.Create(role);
                ApplicationUser defuser = new ApplicationUser();

                defuser.UserName = "MO";
                defuser.Email = "MO@Admins.jobby";
                defuser.PhoneNumber = "01148564500";
                defuser.gender = "Male";
                defuser.maritialStatus = "Single";
                defuser.militaryStatus = "Completed";
                defuser.photo = "Dark.jpg";
                var check = usermangaer.Create(defuser, "MO@Admins.jobby");

                if (check.Succeeded)

                {

                    usermangaer.AddToRole(defuser.Id, role.Name);
                
                }
             
            
            }
        
        
        }
    }
}
