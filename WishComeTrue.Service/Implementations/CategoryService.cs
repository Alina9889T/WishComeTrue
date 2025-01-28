using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;
using WishComeTrue.Common.Enum;
using WishComeTrue.Common.Response;
using WishComeTrue.Common.ViewModels.Category;
using WishComeTrue.DAL.Interfaces;
using WishComeTrue.Service.Interfaces;

namespace WishComeTrue.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<CategoryEntity> _categoriesRepository;

        public CategoryService(IBaseRepository<CategoryEntity> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IBaseResponse<IEnumerable<CategoryViewModel>>> GetCategories()
        {
            try
            {
                var categories = _categoriesRepository.GetAll()
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                });

                return new BaseResponse<IEnumerable<CategoryViewModel>>()
                {
                    Data = categories,
                    Description = "Success",
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<CategoryViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public CategoryEntity GetCategoryById(int categoryId)
        {
            //return _categoriesRepository.GetById(id);
            return _categoriesRepository.GetAll().Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public async Task<IBaseResponse<CategoryEntity>> Create(CategoryViewModel model)
        {
            try
            {
                model.Validate();

                var task = new CategoryEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                };
                await _categoriesRepository.Create(task);

                return new BaseResponse<CategoryEntity>()
                {
                    Description = "Category created!",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CategoryEntity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CategoryEntity>> Update(CategoryViewModel model)
        {
            try
            {
                model.Validate();

                var category = GetCategoryById(model.Id);
                if (category == null)
                {
                    return new BaseResponse<CategoryEntity>()
                    {
                        Description = "Category to update not found",
                        StatusCode = StatusCode.NotFound
                    };
                }

                category.Name = model.Name;
                await _categoriesRepository.Update(category);

                return new BaseResponse<CategoryEntity>()
                {
                    Description = "Category edited!",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CategoryEntity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CategoryEntity>> Delete(int categoryId)
        {
            try
            {
                var category = GetCategoryById(categoryId);

                if (category == null)
                {
                    return new BaseResponse<CategoryEntity>()
                    {
                        Description = "Category not found",
                        StatusCode = StatusCode.NotFound
                    };
                }

                await _categoriesRepository.Delete(category);

                return new BaseResponse<CategoryEntity>()
                {
                    Description = "Category deleted!",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CategoryEntity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
