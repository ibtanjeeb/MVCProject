using My.DataAccess.Repository.IRepository;
using MyMVC.DataAccess.Data;
using MyMVC.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMVC.DataAccess.Repository
{
     public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Season = new SeasonRepository(_db);
        }

        

        public ISeasonRepository Season { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
