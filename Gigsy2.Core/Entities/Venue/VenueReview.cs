using Gigsy2.Core.Entities.Artist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Venue
{
    public class VenueReview
    {
        [Key]
        public Guid Id { get; set; }

        // Foreign key to venue
        public Guid VenueProfileId { get; set; }

        // Navigation property to venue
        public VenueProfile Venue { get; set; } = null!;

        // Author identification
        public Guid AuthorId { get; set; }

        // Discriminator field to determine the type of author
        [Required]
        public AuthorType AuthorType { get; set; }

        // Review content
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; } = string.Empty;

        // Metadata
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsVerified { get; set; } = false;
        public bool IsHidden { get; set; } = false;

        // Optional: Author navigation properties 
        // These will need custom configuration in OnModelCreating
        public ArtistProfile? ArtistAuthor { get; set; }
        // public HostProfile? HostAuthor { get; set; }
    }
    
    // Define author types
    public enum AuthorType
    {
        Artist = 1,
        Host = 2
    }
}
