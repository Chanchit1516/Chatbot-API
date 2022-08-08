namespace Chatbot_API.DTOs.Requests
{
    public class MessageRequest
    {
        public int UserId { get; set; }
        public string? UserType { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; }
        public bool IsPressTopic { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TimeStampString { get; set; }
    }
}
