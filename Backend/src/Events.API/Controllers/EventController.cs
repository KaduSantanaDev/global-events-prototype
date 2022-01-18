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
using Events.Application.DTOs;

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
                if (events == null) return NoContent();

                

                return Ok(events);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal Server Error. Error: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getEvent = await _eventService.GetEventByIdAsync(id, true);
                if (getEvent == null) return NoContent();

                return Ok(getEvent);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal Server Error. Error: {e.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTheme(string tema)
        {
            try
            {
                var getEvent = await _eventService.GetEventsByThemeAsync(tema, true);
                if (getEvent == null) return NoContent();

                return Ok(getEvent);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal Server Error. Error. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventDto model)
        {
            try
            {
                var newEvento = await _eventService.AddEvents(model);
                if (newEvento == null) return NoContent();

                return Ok(newEvento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal Server Error. Error: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventDto model)
        {
            try
            {
                var updatedEvent = await _eventService.UpdateEvent(id, model);
                if (updatedEvent == null) return NoContent();

                return Ok(updatedEvent);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error on updating an event. Error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var getEvent = await _eventService.GetEventByIdAsync(id, true);
                if (getEvent == null) return NoContent();

                return await _eventService.DeleteEvent(id) ?
                       Ok("Deleted") :
                       throw new Exception("Not Especified Error");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error on delete. Error: {e.Message}");
            }
        }
    }
}
