using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Repositories.Abstraction
{
   public interface IRepository<T> where  T: class
    {
        T GetById(int id); 
        ICollection<T> GetAll();

        bool Add(T Entity);

        bool Remove(T Entity);

        bool Update(T Entity);
    }
}
