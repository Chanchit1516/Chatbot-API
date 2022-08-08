namespace Chatbot_API.DTOs.Responses
{
    public class GetMessageResponse
    {
        public GetMessageResponse()
        {
            Lists = new List<MessageResponseDetails>();
        }
        public int UserId { get; set; }
        public string? UserType { get; set; }
        public bool IsFirstLoad { get; set; }
        public List<MessageResponseDetails> Lists { get; set; }
    }
}
