namespace Chatbot_API.Entities.Customs
{
    public class CHAT_HISTORY_ALL
    {
        public CHAT_HISTORY_ALL()
        {
            LIST = new List<CHAT_HISTORY_ALL_DETAILS>();
        }
        public int USER_ID { get; set; }
        public string? USER_TYPE { get; set; }
        public List<CHAT_HISTORY_ALL_DETAILS> LIST { get; set; }
    }

    public class CHAT_HISTORY_ALL_DETAILS
    {
        public CHAT_HISTORY_ALL_DETAILS()
        {
            TOPIC = new List<string>();
        }
        public string? MESSAGE { get; set; }
        public List<string> TOPIC { get; set; }
        public string? TOPIC_STRING { get; set; }
        public DateTime? TIME_STAMP { get; set; }
        public int? BUTTON_ID { get; set; }
        public string? USER_TYPE { get; set; }
        public string? TYPE { get; set; }
       
}


}
