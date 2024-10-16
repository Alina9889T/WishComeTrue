﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
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
