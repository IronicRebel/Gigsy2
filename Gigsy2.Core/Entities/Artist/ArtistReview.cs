
namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistReview
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; } // 1-5 stars
        public DateTime CreatedAt { get; set; }

    }
}

