using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Events.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class EventController : ControllerBase
   {
      public IEnumerable<Event> _event = new Event[] {
         new Event() {
            EventId = 1,
            Theme = "Angular 13 e .NET 6",
            Local = "São Paulo",
            Batch = "1 lote",
            NumPeople = 250,
            DateEvent = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            UrlImage = "foto.png"        
         },
         new Event() {
            EventId = 2,
            Theme = "Angular 13 e Suas Novidades",
            Local = "Rio de Janeiro",
            Batch = "2 lote",
            NumPeople = 400,
            DateEvent = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
            UrlImage = "foto2.png"        
         }
      };
      public EventController()
      {
           
      }

      [HttpGet]
      public IEnumerable<Event> Get()
      {
         return _event;
      }

      [HttpGet("{id}")]
      public IEnumerable<Event> Get(int id)
      {
         return _event.Where(e => e.EventId == id);
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
