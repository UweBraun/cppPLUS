using cppPLUS_2407.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using cppPLUS_2407.Code;

namespace cppPLUS_2407.Controllers
{

    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Title = "CPP_Public";
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return RedirectToAction("Index", "PersonalMasters");
            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            string userID = $"UserID: {User.Identity.GetAppUserId()}";

            ViewBag.User = userID;

            return View();
        }
    }
}