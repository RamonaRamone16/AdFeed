﻿using AdFeed.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.Repositories.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Create(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        void Remove(T entity);
    }
}
