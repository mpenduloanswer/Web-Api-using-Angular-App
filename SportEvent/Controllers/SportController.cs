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
    public class SportController : ControllerBase
    {
        #region 
        private readonly SportDbContext _db;

        public SportController(SportDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Sport Sport  { get; set; }

        [TempData]
        public string Message { get; set; }


        #endregion

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Sport>> Get()
        {
            return _db.sports.FromSql("ReadAllSport").ToList();
         


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Sport> Get(int id)
        {
             
            return await _db.sports.FromSql($"ReadSportByID {id}").FirstOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Sport sport)
        {
            var sportRep = new SportRepository(_db);
            var result = await sportRep.SaveSport(sport);
            return NoContent();
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<Sport> UpdateAsync(int id,  Sport Sport)
        {
            SportRepository sportRepository = new SportRepository(_db);

            var results = await sportRepository.UpdateSport(Sport);

            if (results > 0)
            {
                Message = "Sport  successfully updated";
            }
            else
            {
                Message = "Something went wrong";
            }

            return Sport;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var SportRep = new SportRepository(_db);
            var Result = SportRep.DeleteSport(id);
        }
    }
}
