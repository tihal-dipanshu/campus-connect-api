using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.DataModels
{
    public class EventCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation property for related events (if needed)
        public virtual ICollection<Event> Events { get; set; }
    }
}
