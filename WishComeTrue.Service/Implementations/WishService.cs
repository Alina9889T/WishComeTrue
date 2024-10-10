using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;
using WishComeTrue.Common.Enum;
using WishComeTrue.Common.Response;
using WishComeTrue.Common.Constants;
using WishComeTrue.Common.ViewModels.Wish;
using WishComeTrue.DAL.Interfaces;
using WishComeTrue.Service.Interfaces;

namespace WishComeTrue.Service.Implementations
{
    public class WishService : IWishService
    {
        private readonly IBaseRepository<WishEntity> _wishesRepository;

        public WishService(IBaseRepository<WishEntity> wishesRepository)
        {
            _wishesRepository = wishesRepository;
        }

        public async Task<IBaseResponse<IEnumerable<WishViewModel>>> GetWishes(bool recent = false, bool onlyActive = false, bool onlyFulFilled = false)
        {
            try
            {
                var wishes = _wishesRepository.GetAll();

                if (onlyActive)
                {
                    wishes = wishes.Where(x => !x.FulFilled);
                };

                if (onlyFulFilled)
                {
                    wishes = wishes.Where(x => x.FulFilled);
                }

                if (recent)
                {
                    wishes = wishes.Take(Constants.RECENT_WISHES_AMOUNT);
                };


                var resultWishes = wishes.OrderByDescending(x => x.Created)
                .Select(x => new WishViewModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Description = x.Description,
                     Link = x.Link,
                     Created = x.Created.ToLongDateString(),
                     FulFilled = x.FulFilled ? "Yes :)" : "Not yet :(",
                 });

                return new BaseResponse<IEnumerable<WishViewModel>>()
                {
                    Data = resultWishes,
                    Description = "Success",
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WishViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
