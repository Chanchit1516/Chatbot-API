using AutoMapper;
using Chatbot_API.Data;
using Chatbot_API.DTOs.Requests;
using Chatbot_API.DTOs.Responses;
using Chatbot_API.Entities;
using Chatbot_API.Entities.Customs;
using Chatbot_API.Interfaces;

namespace Chatbot_API.Services
{
    public class ChatbotService : IChatbotService
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ChatbotService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MessageResponse> SendAsync(MessageRequest request)
        {
            //if (request.UserType == "DSSC") request.UserId = 2;

            //var dateNow = DateTime.Parse(request.TimeStampString);
            var dateNow = DateTime.Now;
            var checkMessage = _dbContext.CHAT_HISTORIE.Any(s => s.USER_ID == 2 && !s.IS_COMPLTE);

            bool isFirstMessage = false;
            if (!checkMessage && request.UserType == "DEALER")
            {
                isFirstMessage = true;
                var chatHistoryModel = new CHAT_HISTORIE();
                chatHistoryModel.USER_ID = request.UserId;
                chatHistoryModel.USER_TYPE = request.UserType;
                chatHistoryModel.IS_COMPLTE = false;
                chatHistoryModel.CREATED_BY = request.UserId;
                chatHistoryModel.CREATED_DATETIME = dateNow;
                chatHistoryModel.UPDATE_DATETIME = dateNow;
                _dbContext.CHAT_HISTORIE.Add(chatHistoryModel);
                _dbContext.SaveChanges();

            }

            var response = new MessageResponse();
            response.UserId = request.UserId;
            response.UserType = request.UserType;
            response.IsFirstLoad = false;
            response.Lists.Add(new MessageResponseDetails() { Message = request.Message, Type = request.Type, TimeStamp = dateNow });

            if (isFirstMessage)
            {
                response.Lists.Add(new MessageResponseDetails() { Message = "สวัสดีค่ะ ติดต่อสอบถาม กรุณาเลือกกลุ่ม Support ที่ต้องการได้เลยค่ะ", Type = request.Type, TimeStamp = dateNow });
                response.Lists.Add(new MessageResponseDetails() { Topic = { "DSSC", "SCG_PARTNER", "ติดต่อเจ้าหน้าที่" }, ButtonId = 1, Type = request.Type, TimeStamp = dateNow });



            }
            else
            {
                //var chatHistoryDetails = _dbContext.CHAT_HISTORIE_DETAIL.OrderByDescending(s => s.TIME_STAMP).FirstOrDefault(s => s.CHAT_HISTORIE.USER_ID == 2 && !s.CHAT_HISTORIE.IS_COMPLTE);
                if (request.IsPressTopic)
                {
                    if (request.Message == "DSSC")
                    {
                        response.Lists.Add(new MessageResponseDetails() { Message = "DSSC สวัสดีค่ะ", Type = request.Type, TimeStamp = dateNow });
                        response.Lists.Add(new MessageResponseDetails() { Topic = { "สอบถามสถานะ Quotation", "ติดต่อเจ้าหน้าที่" }, ButtonId = 1, Type = request.Type, TimeStamp = dateNow });
                    }
                    else if (request.Message == "SCG_PARTNER")
                    {
                        response.Lists.Add(new MessageResponseDetails() { Message = "SCG_PARTNER สวัสดีค่ะ", Type = request.Type, TimeStamp = dateNow });
                        response.Lists.Add(new MessageResponseDetails() { Topic = { "สอบถามสถานะ SCG_PARTNER", "ติดต่อเจ้าหน้าที่" }, ButtonId = 1, Type = request.Type, TimeStamp = dateNow });

                    }
                    else if (request.Message == "ติดต่อเจ้าหน้าที่")
                    {
                        response.Lists.Add(new MessageResponseDetails() { Message = "CASE 123", ButtonId = 2, Type = request.Type, TimeStamp = dateNow });
                    }
                    else if (request.Message == "สอบถามสถานะ Quotation")
                    {
                        response.Lists.Add(new MessageResponseDetails() { Message = "กรุณากรอก Quotation Number ค่ะ", Type = request.Type, TimeStamp = dateNow });

                    }
                }
            }

            var chatHistory = _dbContext.CHAT_HISTORIE.FirstOrDefault(s => s.USER_ID == 2 && !s.IS_COMPLTE);
            if (chatHistory != null)
            {
                int i = 0;
                foreach (var item in response.Lists)
                {

                    var userType = i == 0 ? request.UserType : "DSSC";
                    var createBy = i == 0 ? request.UserId : 1;
                    var chatHistoryDetail = new CHAT_HISTORIE_DETAIL();
                    chatHistoryDetail.MESSAGES = item.Message;
                    chatHistoryDetail.IS_TOPIC = item.Topic.Count > 0 ? true : false;
                    chatHistoryDetail.CHAT_HISTORIE_ID = chatHistory.CHAT_HISTORIE_ID;
                    chatHistoryDetail.TOPICS = item.Topic.Count > 0 ? String.Join(",", item.Topic) : "";
                    chatHistoryDetail.CREATED_BY = createBy;
                    chatHistoryDetail.USER_TYPE = userType;
                    chatHistoryDetail.BUTTON_ID = item.ButtonId;
                    chatHistoryDetail.TIME_STAMP = dateNow;
                    _dbContext.CHAT_HISTORIE_DETAIL.Add(chatHistoryDetail);
                    i++;
                }
                _dbContext.SaveChanges();
            }

            return response;
        }

        public async Task<GetMessageResponse> GetChatHistoryByIdAsync(GetMessageRequest request)
        {
            var chatHistory = _dbContext.CHAT_HISTORIE;

            var query =
                (from ch in _dbContext.CHAT_HISTORIE
                 where ch.USER_ID == 2 && ch.IS_COMPLTE == false
                 select new CHAT_HISTORY_ALL()
                 {
                     USER_ID = ch.USER_ID,
                     USER_TYPE = ch.USER_TYPE,
                     LIST = (from chd in _dbContext.CHAT_HISTORIE_DETAIL
                             where ch.CHAT_HISTORIE_ID == chd.CHAT_HISTORIE_ID
                             select new CHAT_HISTORY_ALL_DETAILS()
                             {
                                 MESSAGE = chd.MESSAGES,
                                 BUTTON_ID = chd.BUTTON_ID,
                                 TOPIC_STRING = chd.TOPICS,
                                 TIME_STAMP = chd.TIME_STAMP,
                                 USER_TYPE = chd.USER_TYPE,
                             }).ToList()
                 }).FirstOrDefault();

            var response = new GetMessageResponse();
            if (query != null)
            {
                response.UserId = query.USER_ID;
                response.UserType = query.USER_TYPE;
                response.IsFirstLoad = true;

                for (int i = 0; i < query.LIST.Count(); i++)
                {
                    var chatMessageDetailModel = new MessageResponseDetails();
                    chatMessageDetailModel.Message = query.LIST[i].MESSAGE;
                    chatMessageDetailModel.Topic = !string.IsNullOrEmpty(query.LIST[i].TOPIC_STRING) ? query.LIST[i].TOPIC_STRING.Split(',').ToList() : new List<string>();
                    chatMessageDetailModel.ButtonId = query.LIST[i].BUTTON_ID;
                    chatMessageDetailModel.Type = request.UserType.ToUpper() == query.LIST[i].USER_TYPE?.ToUpper() ? "sent" : "received";
                    chatMessageDetailModel.TimeStamp = query.LIST[i].TIME_STAMP;
                    chatMessageDetailModel.TimeStamp = query.LIST[i].TIME_STAMP;
                    chatMessageDetailModel.UserType = query.LIST[i].USER_TYPE;
                    //if (i > 0 &&
                    //    query.LIST[i].TIME_STAMP.Value.Date == query.LIST[i - 1].TIME_STAMP.Value.Date &&
                    //    query.LIST[i].TIME_STAMP.Value.Minute == query.LIST[i - 1].TIME_STAMP.Value.Minute &&
                    //    query.LIST[i].USER_TYPE == query.LIST[i - 1].USER_TYPE)
                    //{
                    //    response.Lists[i - 1].TimeStamp = null;
                    //}
                    //chatMessageDetailModel.TimeStamp = query.LIST[i].TIME_STAMP;
                    response.Lists.Add(chatMessageDetailModel);
                }
            }
            return response;
        }
    }
}
