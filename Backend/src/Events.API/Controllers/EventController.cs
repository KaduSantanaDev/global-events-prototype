using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.API.Data;
using Events.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Events.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventController : ControllerBase
  {
   private readonly DataContext _context;
   public EventController(DataContext context)
   {
      _context = context;

   }

   [HttpGet]
   public IEnumerable<Event> Get()
   {
      return _context.Events;
   }

   [HttpGet("{id}")]
   public Event Get(int id)
   {
      return _context.Events.FirstOrDefault(e => e.EventId == id);
   }

   [HttpPost]
   public string Post()
   {
      return "Post Exemple";
   }

    [HttpPut("{id}")]
   public string Put(int id)
   {
      return $"Put Exemple {id}";
   }

   [HttpDelete("{id}")]
   public string Delete(int id)
   {
      return "Value";
   }
  }
}
