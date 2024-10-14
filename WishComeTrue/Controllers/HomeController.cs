using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WishComeTrue.Models;
using WishComeTrue.Service.Interfaces;

namespace WishComeTrue.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWishService _wishService;
        public HomeController(IWishService wishService)
        {
            _wishService = wishService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _wishService.GetWishes(recent: true);
            return View(response.Data);
        }

        public async Task<IActionResult> RecentWishesHandler()
        {
            var response = await _wishService.GetWishes(recent: true);
            return Json(new { response.Data });
        }
    }
}
