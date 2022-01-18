using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.DTOs
{
    public class BatchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime InicialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int Quantity { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
    }
}
