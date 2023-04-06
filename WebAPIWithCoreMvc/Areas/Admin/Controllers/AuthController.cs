using Microsoft.AspNetCore.Mvc;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
