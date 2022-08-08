using AutoMapper;
using Chatbot_API.DTOs.Requests;
using Chatbot_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static Chatbot_API.Hubs;

namespace Chatbot_API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ChatbotController : Controller
    {
        private IChatbotService _chatbotService;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatbotController(IChatbotService chatbotService, IMapper mapper, IHubContext<ChatHub> hubContext)
        {
            _chatbotService = chatbotService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest([FromBody] MessageRequest request)
        {
            var res = await _chatbotService.SendAsync(request);
            _hubContext.Clients.All.SendAsync("ReceiveOne", res);
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetChatHistoryById([FromQuery]GetMessageRequest request)
        {
            var res = await _chatbotService.GetChatHistoryByIdAsync(request);
            return Ok(res);
        }

    }
}
