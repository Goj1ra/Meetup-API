using Meetup.API.Data;
using Meetup.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly AppDbContext appDbContext;
        public EventController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var cards = await appDbContext.Events.ToListAsync();
            return Ok(cards);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetEvent")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var singleEvent = await appDbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if(singleEvent != null)
            {
                return Ok(singleEvent);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Event not found" });
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventModel eventModel)
        {
            await appDbContext.Events.AddAsync(eventModel);
            await appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent), new { eventModel.Id }, eventModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] EventModel eventModel)
        {
            var existingEvent = await appDbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEvent != null)
            {
                existingEvent.Title = eventModel.Title;
                existingEvent.TimeOfTheEvent = eventModel.TimeOfTheEvent;
                existingEvent.Speaker = eventModel.Speaker;
                existingEvent.Venue = eventModel.Venue;
                await appDbContext.SaveChangesAsync();
                return Ok(existingEvent);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong with update" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            var existingEvent = await appDbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEvent != null)
            {
                appDbContext.Events.Remove(existingEvent);
                await appDbContext.SaveChangesAsync();
                return Ok(existingEvent);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong with delete" });
        }
    }
}
