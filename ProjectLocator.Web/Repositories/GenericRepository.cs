﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectLocator.Database.Models;
using ProjectLocator.Database.Contexts;

namespace ProjectLocator.Web.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //protected readonly SchoolContext _schoolContext;

        //public GenericRepository(SchoolContext schoolContext)
        //{
        //    _schoolContext = schoolContext;
        //}

        //public async Task Delete(int id)
        //{
        //    var entity = await GetById(id);
        //    _schoolContext.Set<TEntity>().Remove(entity);
        //    await _schoolContext.SaveChangesAsync();
        //}

        //public async Task<TEntity> GetById(int id)
        //{
        //    return await _schoolContext.Set<TEntity>().FirstOrDefaultAsync(o => o.Id == id);
        //}

        //public IQueryable<TEntity> GetByQuery()
        //{
        //    return _schoolContext.Set<TEntity>();
        //}

        //public async Task<TEntity> Post(TEntity item)
        //{
        //    await _schoolContext.Set<TEntity>().AddAsync(item);
        //    await _schoolContext.SaveChangesAsync();

        //    return await GetById(item.Id);
        //}

        //public async Task<TEntity> Put(TEntity item)
        //{
        //    _schoolContext.Set<TEntity>().Update(item);
        //    await _schoolContext.SaveChangesAsync();

        //    return await GetById(item.Id);
        //}
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetByQuery()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Post(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Put(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
