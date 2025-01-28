using Microsoft.AspNetCore.Mvc;
using WishComeTrue.Common.ViewModels.Category;
using WishComeTrue.Common.ViewModels.Wish;
using WishComeTrue.Service.Interfaces;

namespace WishComeTrue.Controllers
{
    public class WishesController : Controller
    {
        private readonly IWishService _wishService;
        private readonly ICategoryService _categoriesService;
        public WishesController(IWishService wishService, ICategoryService categoriesService)
        {
            _wishService = wishService;
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> ActiveWishesHandler()
        {
            var response = await _wishService.GetWishes(onlyActive: true);
            return Json(new { response.Data });
        }

        public async Task<IActionResult> FulFilledWishesHandler()
        {
            var response = await _wishService.GetWishes(onlyFulFilled: true);
            var rsp = Json(new { response.Data }).ToString();
            return Json(new { response.Data });
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoriesService.GetCategories();
            return View(response.Data);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WishViewModel model)
        {
            var response = await _wishService.Create(model);

            if (response.StatusCode == Common.Enum.StatusCode.OK)
            {
                return Ok(new { description = response.Description });
            };
            return BadRequest(new { description = response.Description });
        }

        [HttpPost]
        public async Task<IActionResult> Update(WishViewModel model)
        {
            var response = await _wishService.Update(model);

            if (response.StatusCode == Common.Enum.StatusCode.OK)
            {
                return Ok(new { description = response.Description });
            };
            return BadRequest(new { description = response.Description });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(WishViewModel model)
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
