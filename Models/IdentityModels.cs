using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Linq;

namespace cppPLUS_2407.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            string aspnetUserId = userIdentity.GetUserId();
            int loginId = GetLoginInFromAspNetUserId(aspnetUserId);
            userIdentity.AddClaim(new Claim("http://www.germanyconsulting.de", loginId.ToString()));

            return userIdentity;
        }

        private int GetLoginInFromAspNetUserId(string aspnetUserId)
        {
            using (cppPLUSEntities context = new cppPLUSEntities())
            {
                int result = context.PersonalMasters.Where(w => w.ASPID == aspnetUserId).Select(s => s.UserID).First();
                return result;
            }
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}