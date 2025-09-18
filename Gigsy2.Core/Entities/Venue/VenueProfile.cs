using Gigsy2.Core.Entities.Booking;
using Gigsy2.Core.Entities.Common;
using Gigsy2.Core.Entities.Gig;
using System.ComponentModel.DataAnnotations;

namespace Gigsy2.Core.Entities.Venue
{
    public class VenueProfile
    {
        [Key]
        public int vpId { get; set; } // Primary key (venue profile ID)
        
        public Guid gupId { get; set; } // For linking to Gigsy2User

        public Guid OwnerHostId { get; set; } // For linking to the owner Host Profile

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // public List<string> VenuePhotos { get; set; } = [];
        // public List<VenueFacility> Facilities { get; set; } = [];
        public ContactInfo VenueContactInfo { get; set; } = new ContactInfo();

        public List<GigReview>? VenueGigReviews { get; set; }

        // Tracking fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // These can be uncommented when you have the classes defined
        // public List<BookingItem> Bookings { get; set; } = [];
        // public List<VenueReview> Reviews { get; set; } = [];
    }
}
