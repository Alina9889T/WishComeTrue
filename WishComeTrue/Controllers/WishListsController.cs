using Microsoft.AspNetCore.Mvc;

namespace WishComeTrue.Controllers
{
    public class WishListsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
