using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Venue
{
    internal class VenueReview
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid VenueId { get; set; }
        public int Rating { get; set; } // e.g., 1 to 5
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
    }
}
