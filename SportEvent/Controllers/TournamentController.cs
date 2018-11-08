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
    public class TournamentController : ControllerBase
    {
        #region 
        private readonly SportDbContext _db;

        public TournamentController(SportDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Tournament Tournament  { get; set; }
        public IList<Tournament> tournaments { get; set; }
        [TempData]
        public string Message { get; set; }

        #endregion

        // GET api/values
        [HttpGet]
        public async Task<IList<Tournament>> GetAsync()
        {
            return await  _db.tournaments.FromSql("ReadAllTournament").ToListAsync();

        }
     
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Tournament> Get(int id)
        {
             
            return await _db.tournaments.FromSql($"ReadTournamentByID {id}").FirstOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task<Tournament>PostAsync([FromBody] Tournament tournament)
        {
            var TournamentRep = new TournamentRepository(_db);
            var result = await TournamentRep.SaveTournament(tournament);

            return result;
        }
   
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<List<Tournament>>UpdateAsync([FromBody] Tournament tournament )
        {
            try
            {
                TournamentRepository TournamentRepository = new TournamentRepository(_db);

              return await TournamentRepository.UpdateTournament(tournament);

            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
               

            return null;
        }
 
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<List<Tournament>> Delete(int id)
        {   
                var TournRep = new TournamentRepository(_db);
                var Result = await TournRep.DeleteTournament(id);

               return Result;       
        }
 
    }
}
