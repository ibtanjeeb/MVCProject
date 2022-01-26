using Microsoft.EntityFrameworkCore;
using SMECommerce.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMECommerceRepositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;

        }

       private DbSet<T> Table { get
            {
                return _db.Set<T>();
                    } 
        }
        public virtual bool Add(T Entity)
        {
            _db.Add(Entity);

            return _db.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public abstract T GetById(int id);
        

        public virtual bool Remove(T Entity)
        {
            _db.Remove(Entity);

            return _db.SaveChanges() > 0;
        }

        public virtual bool Update(T Entity)
        {
            _db.Update(Entity);

            return _db.SaveChanges() > 0;

        }
    }
}
