using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace KorsatkoApp.Areas.Admin.Controllers {

    [Area("Admin")]
    public class HomeController : Controller {
        private readonly IToastNotification _toastNotification;
        public HomeController(IToastNotification toastNotification) {
            _toastNotification = toastNotification;
        }
        public IActionResult Index() {
            string user = User.Identity.Name;
            //Success
            _toastNotification.AddInfoToastMessage("مرحبا ,"+user);
            return View();
        }

    }
}
