
using System.ComponentModel.DataAnnotations;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistProfile
    {
        public Guid UserProfileId { get; set; }

        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }

        // Location Details
        public string NearestTown { get; set; } = string.Empty;

        public double? Latitude { get; set; }  // Optional: for future mapping/filtering
        public double? Longitude { get; set; } // Optional: for future mapping/filtering

        // Social Media Handles
        public string? SocialHandleSoundCloud { get; set; }
        public string? SocialHandleInstagram { get; set; }
        public string? SocialHandleX { get; set; }
        public string? SocialHandleLinkedIn { get; set; }
        public string? SocialHandleMixcloud { get; set; }
        public string? SocialHandleYouTube { get; set; }
        public string? SocialHandleFacebook { get; set; }
        public string? SocialHandleSpotify { get; set; }

        public string? WebsiteUrl { get; set; }
    }
}
