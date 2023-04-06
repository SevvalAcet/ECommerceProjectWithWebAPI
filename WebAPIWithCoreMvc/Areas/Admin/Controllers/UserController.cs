using Microsoft.AspNetCore.Mvc;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
