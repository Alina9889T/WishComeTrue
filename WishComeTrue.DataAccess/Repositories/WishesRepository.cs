using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;
using WishComeTrue.DAL.Interfaces;

namespace WishComeTrue.DAL.Repositories
{
    public class WishesRepository: IBaseRepository<WishEntity>
    {
        private readonly AppDBContext _appDBContext;
        public WishesRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IQueryable<WishEntity> GetAll()
        {
            return _appDBContext.Wishes;
        }
    }
}
