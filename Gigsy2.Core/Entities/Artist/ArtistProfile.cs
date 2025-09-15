
using Gigsy2.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

using Gigsy2.Core.Entities.Booking;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistProfile
    {
        [Key]
        public int apId { get; set; }
        public Guid gupId { get; set; }

        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }

        // Location Details
        public string? NearestTown { get; set; } = string.Empty;

        public double? Latitude { get; set; }  // Optional: for future mapping/filtering
        public double? Longitude { get; set; } // Optional: for future mapping/filtering

        public List<PerformanceType> PerformanceTypes { get; set; } = new();
        public List<BookingItem> Bookings { get; set; } = new();
        public List<ArtistReview> Reviews { get; set; } = new();


        public ContactInfo ContactInfo { get; set; } = new();
        public ArtistSocialMediaLinks ArtistSocialMediaLinks { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
