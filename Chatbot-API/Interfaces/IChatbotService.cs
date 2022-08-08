using Chatbot_API.DTOs.Requests;
using Chatbot_API.DTOs.Responses;

namespace Chatbot_API.Interfaces
{
    public interface IChatbotService
    {
        Task<MessageResponse> SendAsync(MessageRequest request);
        Task<GetMessageResponse> GetChatHistoryByIdAsync(GetMessageRequest request);
    }
}
