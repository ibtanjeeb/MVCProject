using MyMVC.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ISeasonRepository Season { get; }
       

        void Save();
    }
}
