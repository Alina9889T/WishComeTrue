using Microsoft.AspNetCore.Mvc;
using WishComeTrue.Common.ViewModels.Wish;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWish(WishViewModel model)
        {
            var response = await _wishService.Create(model);

            if (response.StatusCode == Common.Enum.StatusCode.OK)
            {

                return Ok(new { description = response.Description });
            };
            return BadRequest(new { description = response.Description });
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

        [HttpPost]
        public async Task<IActionResult> DeleteWish(WishViewModel model)
        {
            var response = await _wishService.Delete(model.Id);

            if (response.StatusCode == Common.Enum.StatusCode.OK)
            {
                return Ok(new { description = response.Description });
            };
            return BadRequest(new { description = response.Description });
        }
    }
}
