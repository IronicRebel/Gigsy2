using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistAvailability
    {
        [Key]
        public Guid ArtistAvailabilityId { get; set; }

        [ForeignKey("ArtistProfileId")]
        public ArtistProfile? ArtistProfile { get; set; }

        // Stuff about availability

        // Time of day availability
        public bool IsAvailableDaytime { get; set; } // Typically 9am-5pm
        public bool IsAvailableEvening { get; set; } // Typically 5pm-10pm
        public bool IsAvailableLateNight { get; set; } // Typically 10pm-2am

        // Weekday availability (Monday-Friday)
        public bool IsAvailableMonday { get; set; }
        public bool IsAvailableTuesday { get; set; }
        public bool IsAvailableWednesday { get; set; }
        public bool IsAvailableThursday { get; set; }
        public bool IsAvailableFriday { get; set; }
        public bool IsAvailableSaturday { get; set; }
        public bool IsAvailableSunday { get; set; }
        
        
        // Minimum notice period required for bookings (in days)
        public int MinimumNoticeDays { get; set; } = 7;

        // Maximum booking period in advance (in days, e.g., can book up to 180 days ahead)
        public int MaximumAdvanceBookingDays { get; set; } = 180;

        // Date ranges when artist is unavailable (e.g., during tours or personal time)
        // These could alternatively be stored in a separate related entity
        [MaxLength(1000)]
        public string? UnavailableDateRanges { get; set; } // Could store as JSON array of date ranges

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

    }
}
