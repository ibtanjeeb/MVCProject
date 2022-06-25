using MyMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMVC.DataAccess.Repository.IRepository
{
   public interface ISeasonRepository:IRepositoryAsync<Season>
    {

        void Update(Season season);
    }
}
