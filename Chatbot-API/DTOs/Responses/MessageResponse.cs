namespace Chatbot_API.DTOs.Responses
{
    public class MessageResponse
    {
        public MessageResponse()
        {
            Lists = new List<MessageResponseDetails>();
        }
        public int UserId { get; set; }
        public string? UserType { get; set; }
        public bool IsFirstLoad { get; set; }
        public List<MessageResponseDetails> Lists { get; set; }
    }

    public class MessageResponseDetails
    {
        public MessageResponseDetails()
        {
            Topic = new List<string>();
        }
        public string? Message { get; set; }
        public List<string> Topic { get; set; }
        public int? ButtonId { get; set; }
        public string? Type { get; set; }
        public string? UserType { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
