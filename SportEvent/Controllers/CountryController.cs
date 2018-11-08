using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportEvent.Models;
using SportEvent.Repository;

namespace SportEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region 
        private readonly SportDbContext _db;

        public CountryController(SportDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Country Country { get; set; }
        public IList<Country> countries { get; set; }
        [TempData]
        public string Message { get; set; }

        #endregion

        // GET api/values
        [HttpGet]
        public async Task<IList<Country>> GetAsync()
        {
            return await _db.countries.FromSql("ReadAllCountry").ToListAsync();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Country> Get(int id)
        {

            return await _db.countries.FromSql($"ReadCountryByID {id}").FirstOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task<Country> PostAsync([FromBody] Country Country )
        {
            var countryRep = new CountryRepository(_db);
            var result = await countryRep.SaveCountry(Country);
            return result;
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<List<Country>> UpdateAsync([FromBody ]Country country)
        {
            CountryRepository CountryRepository = new CountryRepository(_db);

            var results = await CountryRepository.UpdateCountry(country);

            return results;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<List<Country>> Delete(int id)
        {
            var CountryRep = new CountryRepository(_db);
            var Result = await CountryRep.DeleteCountry(id);

            return Result;
        }
    }
}
