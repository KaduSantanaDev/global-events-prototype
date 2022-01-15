using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Persistence;
using Events.Domain;
using Events.Application.Interfaces;
using Events.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Events.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class EventController : ControllerBase
   {
      private readonly IEventService _eventService;
      public EventController(IEventService eventService)
        {
         _eventService = eventService;

        }

      [HttpGet]
      public async Task<IActionResult> Get()
      {
         try
         {
            var events = await _eventService.GetEventsAsync(true);
            if(events == null) return NotFound("Events not found");

            return Ok(events);
         }
         catch (Exception e)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}"); 
         }
      }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getEventId = await _eventService.GetEventByIdAsync(id, true);
                if(getEventId == null) return NotFound("Event not found");

                return Ok(getEventId);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}"); 
            }
        }

        [HttpGet("{theme}/theme")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var getEventId = await _eventService.GetEventsByThemeAsync(theme, true);
                if(getEventId == null) return NotFound("Events not found");

                return Ok(getEventId);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}"); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var newEvent = await _eventService.AddEvents(model);
                if(newEvent == null) return BadRequest("Error on add an event");

                return Ok(newEvent);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError
                , $"Internal Server Error: {e.Message}"); 
                
                
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try
            {
                var newEvent = await _eventService.UpdateEvent(id, model);
                if(newEvent == null) return BadRequest("Error on update an event");

                return Ok(newEvent);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError
                , $"Internal Server Error: {e.Message}"); 
                
                
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventService.DeleteEvent(id) ? 
                Ok("Deleted") : 
                BadRequest("Error on delete an event");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError
                , $"Internal Server Error: {e.Message}"); 
                
                
            }
        }
    }
}
