﻿using System;
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

        public WishEntity GetById(string id)
        {
            return _appDBContext.Wishes.Find(id);
        }

        public async Task Create(WishEntity entity)
        {
            await _appDBContext.Wishes.AddAsync(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task Update(WishEntity entity)
        {
            _appDBContext.Wishes.Update(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task Delete(WishEntity entity)
        {
            _appDBContext.Wishes.Remove(entity);
            await _appDBContext.SaveChangesAsync();
        }
    }
}
