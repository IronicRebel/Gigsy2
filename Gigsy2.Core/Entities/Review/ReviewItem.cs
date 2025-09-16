using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Venue;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Review
{
    public class ReviewItem
    {
        [Key]
        public Guid Id { get; set; }

        // Who is being reviewed
        public Guid TargetProfileId { get; set; }
        public ReviewTargetType TargetType { get; set; }

        // Who wrote the review
        public Guid AuthorProfileId { get; set; }
        public ReviewAuthorType AuthorType { get; set; }

        // Review content
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; } = string.Empty;

        // Metadata
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
        public bool IsVerified { get; set; } = false;
        public bool IsHidden { get; set; } = false;

        // Optional navigation
        public ArtistProfile? ArtistTarget { get; set; }
        public VenueProfile? VenueTarget { get; set; }
        public HostProfile? HostTarget { get; set; }

        public ArtistProfile? ArtistAuthor { get; set; }
        public VenueProfile? VenueAuthor { get; set; }
        public HostProfile? HostAuthor { get; set; }

    }

    public enum ReviewTargetType
    {
        Artist = 1,
        Venue = 2,
        Host = 3
    }

    public enum ReviewAuthorType
    {
        Artist = 1,
        Venue = 2,
        Host = 3
    }

}
