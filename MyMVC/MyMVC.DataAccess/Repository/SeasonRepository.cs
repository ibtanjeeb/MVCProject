using MyMVC.DataAccess.Data;
using MyMVC.DataAccess.Repository.IRepository;
using MyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMVC.DataAccess.Repository
{
    public class SeasonRepository : RepositoryAsync<Season> ,ISeasonRepository
    {

        private readonly ApplicationDbContext _db;

        public SeasonRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Season season)
        {
            var objFromDb = _db.Seasons.FirstOrDefault(s => s.Id == season.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = season.Name;

            }
        }
    }
}
