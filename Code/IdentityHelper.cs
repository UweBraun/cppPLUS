using System.Security.Claims;
using System.Security.Principal;
using System.Linq;

namespace cppPLUS_2407.Code
{
    public static class IdentityHelper
    {
        public static int GetAppUserId(this IIdentity Identity)
        {
            ClaimsIdentity userClaimsIdentity = (ClaimsIdentity)Identity;

            string id = userClaimsIdentity.Claims.Where(w => w.Type == "http://www.germanyconsulting.de").FirstOrDefault().Value;
            return int.Parse(id);
        }
    }
}