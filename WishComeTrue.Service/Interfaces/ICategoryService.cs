using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;
using WishComeTrue.Common.Response;
using WishComeTrue.Common.ViewModels.Category;

namespace WishComeTrue.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IBaseResponse<IEnumerable<CategoryViewModel>>> GetCategories();

        public CategoryEntity GetCategoryById(int categoryId);

        Task<IBaseResponse<CategoryEntity>> Create(CategoryViewModel model);

        Task<IBaseResponse<CategoryEntity>> Update(CategoryViewModel model);

        Task<IBaseResponse<CategoryEntity>> Delete(int categoryId);
    }
}
