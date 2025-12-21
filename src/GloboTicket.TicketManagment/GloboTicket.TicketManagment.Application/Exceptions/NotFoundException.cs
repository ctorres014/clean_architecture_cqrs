namespace GloboTicket.TicketManagment.Application.Exepctions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string name, string key)
            : base($"{name} ({key}) is not found")
        {
            
        }
    }
}
