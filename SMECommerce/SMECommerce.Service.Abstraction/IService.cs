﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services.Abstraction
{
    public interface IService<T> where T:class
    {
        bool Add(T entity);

        bool Remove(T entity);

        bool Update(T entity);

        ICollection<T> GetAll();

        T GetById(int id);
    }
}
