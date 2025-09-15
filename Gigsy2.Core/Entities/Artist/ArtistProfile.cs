
using Gigsy2.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

using Gigsy2.Core.Entities.Booking;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistProfile
    {
        [Key]
        public Guid apId { get; set; } // The primary key for the ArtistProfile entity

        public Guid gupLUId { get; set; } // Lookup GUID to link with Gigsy2User

        public string? StageName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }

        // Location Details
        public string? NearestTown { get; set; } = string.Empty;

        public double? Latitude { get; set; }  // Optional: for future mapping/filtering
        public double? Longitude { get; set; } // Optional: for future mapping/filtering

        public List<BookingItem> ArtistBookingItems { get; set; } = new();
        public List<ArtistReview> ArtistReviews { get; set; } = new();

        public ArtistAvailability AArtistAvailability { get; set; } = null;

        public ArtistContactInfo ArtistContactInfo { get; set; } = new();
        public ArtistSocialMediaLinks ArtistSocialMediaLinks { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
