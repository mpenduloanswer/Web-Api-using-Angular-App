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
    public class EventController : ControllerBase
    {
        #region 
        private readonly SportDbContext _db;

        public EventController(SportDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Event Event { get; set; }

        [TempData]
        public string Message { get; set; }
        public List<Event> events { get; set; }

        #endregion

        // GET api/values
        [HttpGet]
        public ActionResult<IList<Event>> Get()
        {
            return events = _db.events.FromSql("ReadAllEvent").ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
             
            return await _db.events.FromSql($"ReadSportByID {id}").FirstOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task<Event> PostAsync([FromBody] Event events)
        {
            try
            {
                var EventRep = new EventRepository(_db);
                var result = await EventRep.SaveEvent(events);
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
            
            return Event;
        }
        // PUT api/values/5

        [HttpPut("{id}")]
        //public async Task<List<Country>> UpdateAsync([FromBody]Country country)
        public async Task<List<Event>> UpdateAsync([FromBody] Event Event )
        {
            try
            {
                EventRepository EventRepository = new EventRepository(_db);

                 return await EventRepository.UpdateEvent(Event);
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }


            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Task< List<Event>> Delete(int id)
        {
            var EventRep = new EventRepository(_db);
            var Result = EventRep.DeleteEvent(id);
            return Result;
        }
    }
}
