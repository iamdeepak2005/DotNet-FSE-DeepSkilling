using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Training.Week4.WebApi.Controllers
{
    // DTO class
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private static readonly List<EventDto> EventDb = new()
        {
            new EventDto { Id = 1, Title = "Summer Music Show", City = "Mumbai" },
            new EventDto { Id = 2, Title = "Food Carnival", City = "Bangalore" }
        };

        // GET: api/events
        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll()
        {
            return Ok(EventDb);
        }

        // GET: api/events/1
        [HttpGet("{id}")]
        public ActionResult<EventDto> GetById(int id)
        {
            var ev = EventDb.Find(e => e.Id == id);
            if (ev == null) return NotFound(new { message = $"Event ID {id} not found." });
            return Ok(ev);
        }

        // POST: api/events (Secured endpoint requiring Authorization headers)
        [HttpPost]
        [Authorize]
        public ActionResult<EventDto> Create([FromBody] EventDto newEvent)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            newEvent.Id = EventDb.Count + 1;
            EventDb.Add(newEvent);
            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
        }

        // DELETE: api/events/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var index = EventDb.FindIndex(e => e.Id == id);
            if (index == -1) return NotFound();
            
            EventDb.RemoveAt(index);
            return NoContent();
        }
    }
}