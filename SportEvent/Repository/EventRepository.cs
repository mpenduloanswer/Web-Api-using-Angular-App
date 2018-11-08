using Microsoft.EntityFrameworkCore;
using SportEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent.Repository
{
    public class EventRepository
    {
        #region Fields and Methods

        private readonly SportDbContext _db;

        public EventRepository(SportDbContext db)
        {
            _db = db;
        }
        public Models.Event Event  { get; set; }
        //public int MyProperty { get; set; }
        #endregion

        public async Task<int> SaveEvent(Event Event )
        {
            return await _db.Database.ExecuteSqlCommandAsync($"InsertEvent {Event.EventName},{Event.SportID},{Event.CountryID},{Event.TournamentID} ,{Event.EventDate}");
        }

        public async Task<List<Event>> DeleteEvent(int id)
        {
            return await _db.events.FromSql($"[dbo].DeleteEventByID {id}").ToListAsync();

        }
        public async Task<List<Event>> GetAllEvent()
        {
            var Event = await _db.events.FromSql("[dbo].[ReadAllEvent]").AsNoTracking().ToListAsync();

            return Event;
        }

        public async Task<List<Event>> UpdateEvent(Event Event )
        {
            return await _db.events.FromSql($"[dbo].UpdateEvent {Event.EventID},{Event.EventName},{Event.EventDate}").ToListAsync();
        }
    }
}
