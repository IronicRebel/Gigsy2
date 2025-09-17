using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gigsy2.Core.Entities.Host;
using Gigsy2.Core.Entities.Venue;

namespace Gigsy2.Core.Entities.Gig
{
    public class GigItem
    {
        public Guid gigId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration 
        { 
            get 
            { 
                return EndTime - StartTime; 
            }
        }

        public GigStatus Status { get; set; } // Upcoming, Completed, Cancelled

        public Guid HostId { get; set; }
        public HostProfile Host { get; set; }

        public Guid VenueId { get; set; }
        public VenueProfile Venue { get; set; }

        public List<Guid>? ArtistIds { get; set; }

        public List<GigReview>? GigReviews { get; set; }
    }

    public enum GigStatus
    {
        Draft,
        Published,
        Upcoming,
        Completed,
        Cancelled
    }


}
