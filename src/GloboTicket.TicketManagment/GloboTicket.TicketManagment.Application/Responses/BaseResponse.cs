namespace GloboTicket.TicketManagment.Application.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();

        public BaseResponse()
        {
            IsSuccess = true;
        }

        public BaseResponse(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        public BaseResponse(string message)
        {
            IsSuccess = true;
            Message = message;
        }
    }
}
