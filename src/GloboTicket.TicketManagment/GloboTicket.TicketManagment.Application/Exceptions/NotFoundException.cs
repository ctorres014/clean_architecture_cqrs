using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, Object key) : base($"{name} ({key} is not found)"){ }
    }
}
