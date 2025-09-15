using System.ComponentModel.DataAnnotations;
using Gigsy2.Core.Entities.Booking;
using Gigsy2.Core.Entities.Common;

namespace Gigsy2.Core.Entities.Venue
{
    public class VenueProfile
    {
        [Key]
        public int vpId { get; set; } // Primary key (venue profile ID)
        
        public Guid gupId { get; set; } // For linking to Gigsy2User
        
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // Location coordinates for mapping
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        
        // public List<string> VenuePhotos { get; set; } = [];
        // public List<VenueFacility> Facilities { get; set; } = [];
        public ContactInfo ContactInfo { get; set; } = new ContactInfo();
        
        // Tracking fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // These can be uncommented when you have the classes defined
        // public List<BookingItem> Bookings { get; set; } = [];
        // public List<VenueReview> Reviews { get; set; } = [];
    }
}
