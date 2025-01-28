using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;
using WishComeTrue.DAL.Interfaces;

namespace WishComeTrue.DAL.Repositories
{
    public class CategoriesRepository : IBaseRepository<CategoryEntity>
    {
        private readonly AppDBContext _appDBContext;
        public CategoriesRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            return _appDBContext.Categories;
        }

        public CategoryEntity GetById(string id)
        {
            return _appDBContext.Categories.Find(id);
        }

        public async Task Create(CategoryEntity entity)
        {
            await _appDBContext.Categories.AddAsync(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task Update(CategoryEntity entity)
        {
            _appDBContext.Categories.Update(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task Delete(CategoryEntity entity)
        {
            _appDBContext.Categories.Remove(entity);
            await _appDBContext.SaveChangesAsync();
        }
    }
}
