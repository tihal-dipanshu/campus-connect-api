using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.DataModels
{
    public class GroupChat
    {
        public int ChatID { get; set; }
        public int EventID { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Event Event { get; set; }
        public virtual ICollection<ChatMessage> Messages { get; set; }
    }
}
