using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chatbot_API.Entities
{
    public class CHAT_HISTORIE_DETAIL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CHAT_HISTORIE_DETAIL_ID { get; set; }

        [ForeignKey("CHAT_HISTORIE")]
        public int CHAT_HISTORIE_ID { get; set; }
        public string? MESSAGES { get; set; }
        public string? TOPICS { get; set; }
        public string? USER_TYPE { get; set; }
        public bool IS_TOPIC { get; set; }
        public int? BUTTON_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime TIME_STAMP { get; set; }
        public CHAT_HISTORIE CHAT_HISTORIE { get; set; }

    }
}
