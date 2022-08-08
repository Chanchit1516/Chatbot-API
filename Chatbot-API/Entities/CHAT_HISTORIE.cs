using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chatbot_API.Entities
{
    public class CHAT_HISTORIE
    {
        public CHAT_HISTORIE()
        {
            CHAT_HISTORIE_DETAILS = new List<CHAT_HISTORIE_DETAIL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CHAT_HISTORIE_ID { get; set; }
        public int USER_ID { get; set; }
        public string? USER_TYPE { get; set; }
        public bool IS_COMPLTE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public DateTime? UPDATE_DATETIME { get; set; }
        public ICollection<CHAT_HISTORIE_DETAIL> CHAT_HISTORIE_DETAILS { get; set; }
    }
}
