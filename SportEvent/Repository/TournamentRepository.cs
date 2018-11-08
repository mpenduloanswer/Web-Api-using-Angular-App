using Microsoft.EntityFrameworkCore;
using SportEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent.Repository
{
    public class TournamentRepository
    {
        #region Fields and Methods

        private readonly SportDbContext _db;

        public TournamentRepository(SportDbContext db)
        {
            _db = db;
        }
        public Models.Tournament Tournament { get; set; }
        #endregion

        public async Task<Tournament> SaveTournament(Tournament tournament)
        {
            return await _db.tournaments.FromSql($"InsertTournament {tournament.TournamentName},{tournament.SportID},{tournament.CountryID} ").FirstOrDefaultAsync();
        }

        public async Task<List<Tournament>> DeleteTournament(int id)
        {
            return await _db.tournaments.FromSql($"DeleteTournamentByID {id}").ToListAsync();

        }
        public async Task<List<Tournament>> GetAllTournament()
        {
            var tournaments = await _db.tournaments.FromSql("[dbo].[ReadAllTournament]").AsNoTracking().ToListAsync();

            return tournaments; 
        }

        public async Task<List<Tournament>> UpdateTournament(Tournament tournament )
        {
            return await _db.tournaments.FromSql($"UpdateTournament {tournament.TournamentID},{tournament.TournamentName}").ToListAsync();
        }

    }

}
