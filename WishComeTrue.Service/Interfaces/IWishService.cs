﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;
using WishComeTrue.Common.Response;
using WishComeTrue.Common.ViewModels.Wish;

namespace WishComeTrue.Service.Interfaces
{
    public interface IWishService
    {
        Task<IBaseResponse<IEnumerable<WishViewModel>>> GetWishes(bool recent = false, bool onlyActive = false, bool onlyFulFilled = false);

        public WishEntity GetWishById(string wishId);

        Task<IBaseResponse<WishEntity>> Create(WishViewModel model);

        Task<IBaseResponse<WishEntity>> Update(WishViewModel model);

        Task<IBaseResponse<WishEntity>> Delete(string wishId);
    }
}
