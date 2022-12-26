using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Dtos
{
    public class CategoryEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }   
        public string Artist { get; set; }
    }
}
