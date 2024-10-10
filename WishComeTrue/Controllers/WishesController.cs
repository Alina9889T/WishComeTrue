using Microsoft.AspNetCore.Mvc;
using WishComeTrue.Service.Interfaces;

namespace WishComeTrue.Controllers
{
    public class WishesController : Controller
    {
        private readonly IWishService _wishService;
        public WishesController(IWishService wishService)
        {
            _wishService = wishService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ActiveWishesHandler()
        {
            var response = await _wishService.GetWishes(onlyActive: true);
            return Json(new { response.Data });
        }

        public async Task<IActionResult> FulFilledWishesHandler()
        {
            var response = await _wishService.GetWishes(onlyFulFilled: true);
            return Json(new { response.Data });
        }
    }
}
