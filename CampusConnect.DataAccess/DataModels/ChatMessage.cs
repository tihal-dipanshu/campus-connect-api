using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.DataModels
{
    public class ChatMessage
    {
        public int MessageID { get; set; }
        public int ChatID { get; set; }
        public int UserID { get; set; }
        public string MessageContent { get; set; }
        public DateTime SentAt { get; set; }

        // Navigation properties
        public virtual GroupChat GroupChat { get; set; }
        public virtual User User { get; set; }
    }
}
