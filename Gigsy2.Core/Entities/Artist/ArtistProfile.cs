
using Gigsy2.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

using Gigsy2.Core.Entities.Booking;
using Gigsy2.Core.Entities.Gig;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistProfile
    {
        [Key]
        public Guid Id { get; set; } // The primary key for the ArtistProfile entity

        [ForeignKey("Gigsy2UserId")]
        public Guid Gigsy2UserId { get; set; } // Lookup GUID to link with Gigsy2User

        public string? StageName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }

        public ArtistSocialMediaLinks? ArtistSocialMediaLinks { get; set; }

        // Location Details including specify a custom touring location - both towns from Google Placeas API
        public string? NearestCity { get; set; } = string.Empty;
        public string? CurrentlyTouringCity { get; set; } = string.Empty; 

        public double? Latitude { get; set; }  // Optional: for future mapping/filtering
        public double? Longitude { get; set; } // Optional: for future mapping/filtering

        // Relations to Common Entities 
        public ArtistContactInfo? ArtistContactInfo { get; set; }
        public List<Genre>? ArtistGenres {  get; set; }

        // Relations to other Entities

        public List<BookingItem>? ArtistBookingItems { get; set; }
        public List<GigReview>? ArtistGigReviews { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

}
