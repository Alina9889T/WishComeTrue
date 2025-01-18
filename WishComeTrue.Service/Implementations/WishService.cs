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
                     Created = x.Created,
                     FulFilled = x.FulFilled,
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

        public WishEntity GetWishById(string id)
        {
            return _wishesRepository.GetById(id);
        }

        public async Task<IBaseResponse<WishEntity>> Create(WishViewModel model)
        {
                try
                {
                    model.Validate();

                    var task = new WishEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = model.Name,
                        Description = model.Description,
                        Link = model.Link,
                        Created = DateTime.Now,
                        FulFilled = false
                    };
                    await _wishesRepository.Create(task);

                    return new BaseResponse<WishEntity>()
                    {
                        Description = "Wish created! :)",
                        StatusCode = StatusCode.OK
                    };
                }
                catch (Exception ex)
                {
                    return new BaseResponse<WishEntity>()
                    {
                        Description = ex.Message,
                        StatusCode = StatusCode.InternalServerError
                    };
                }
        }

        public async Task<IBaseResponse<WishEntity>> Update(WishViewModel model)
        {
            try
            {
                model.Validate();

                var wish = GetWishById(model.Id);
                if (wish == null)
                {
                    return new BaseResponse<WishEntity>()
                    {
                        Description = "Wish to update not found",
                        StatusCode = StatusCode.NotFound
                    };
                }

                wish.Name = model.Name;
                wish.Description = model.Description;
                wish.Link = model.Link;
                wish.FulFilled = model.FulFilled;
                await _wishesRepository.Update(wish);

                return new BaseResponse<WishEntity>()
                {
                    Description = "Wish edited! :)",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<WishEntity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<WishEntity>> Delete(string wishId)
        {
            try
            {
                var wish = _wishesRepository.GetAll().Where(w => w.Id == wishId).FirstOrDefault();

                if (wish == null)
                {
                    return new BaseResponse<WishEntity>()
                    {
                        Description = "Wish not found",
                        StatusCode = StatusCode.NotFound
                    };
                }

                await _wishesRepository.Delete(wish);

                return new BaseResponse<WishEntity>()
                {
                    Description = "Wish deleted!",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<WishEntity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
