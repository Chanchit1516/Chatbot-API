using AutoMapper;
using Chatbot_API.DTOs.Responses;
using Chatbot_API.Entities;

namespace Chatbot_API.Mapper
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<CHAT_HISTORIE, MessageResponse>().ReverseMap();
        }
    }
}
