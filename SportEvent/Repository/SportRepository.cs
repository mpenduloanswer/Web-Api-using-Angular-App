using Microsoft.EntityFrameworkCore;
using SportEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent.Repository
{
    public class SportRepository
    {
        #region Fields and Methods

        private readonly SportDbContext _db;

        public SportRepository(SportDbContext db)
        {
            _db = db;
        }
        public Models.Sport Sport { get; set; }
        #endregion

        public async Task<int> SaveSport(Sport sport)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"InsertSport {sport.SportName} ");
        }

        public async Task<int> DeleteSport(int id)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"[dbo].DeleteSportByID {id}");

        }
        public async Task<List<Sport>> GetAllSport()
        {
            var sports = await _db.sports.FromSql("[dbo].[ReadAllSport]").AsNoTracking().ToListAsync();

            return sports;
        }

        public async Task<int> UpdateSport(Sport sport)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"[dbo].UpdateSport {sport.SportID},{sport.SportName}");
        }
    }
}
