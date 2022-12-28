using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Response
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public List<string> ValidationErrors { get; set; }

        public BaseResponse() => Success = true;

        public BaseResponse(string messsage, bool success) =>
            (Message, Success) = (messsage, success);
        public BaseResponse(string messsage = null) => 
            (Success, Message) = (true, messsage);

        
    }
}
