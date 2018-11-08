using Microsoft.EntityFrameworkCore;
using SportEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent.Repository
{
    public class CountryRepository
    {
        #region Fields and Methods

        private readonly SportDbContext _db;

        public CountryRepository(SportDbContext db)
        {
            _db = db;
        }
        public Models.Country Country { get; set; }
        public string Message { get; set; }
        #endregion
        public async Task<Country> SaveCountry(Country country)
        {
            try
            {
                return await _db.countries.FromSql($"InsertCountry {country.CountryName}, {country.SportID}").FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                Message= ex.Message;
            }
            return Country;
        }

        public async Task<List<Country>> DeleteCountry(int id)
        {
            return await _db.countries.FromSql($"[dbo].DeleteCountryByID {id}").ToListAsync();

        }

        public async Task<List<Country>> GetAllCountry()
        {
            var Country = await _db.countries.FromSql("[dbo].[ReadAllCountry]").AsNoTracking().ToListAsync();

            return Country;
        }

        public async Task<List<Country>> UpdateCountry(Country country)
        {
            return await _db.countries.FromSql($"[dbo].UpdateCountry {country.CountryID},{country.CountryName}").ToListAsync();
        }

    }
}
