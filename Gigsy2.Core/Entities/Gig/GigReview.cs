using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gigsy2.Core.Entities.Gig
{
    public class GigReview
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Link to the gig
        public Guid GigId { get; set; }
        
        // Reviewer information
        public ReviewRole ReviewerRole { get; set; }
        public Guid ReviewerId { get; set; }
        
        // Reviewee information
        public ReviewRole RevieweeRole { get; set; }
        public Guid RevieweeId { get; set; }

        // Review Content
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(450)]
        public string? Comment { get; set; }
        
        // Review metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation property - just one for the gig
        public GigItem? Gig { get; set; }
        
        // Helper methods instead of navigation properties
        [NotMapped]
        public string ReviewerDisplayName { get; set; } = string.Empty;
        
        [NotMapped]
        public string RevieweeDisplayName { get; set; } = string.Empty;
    }

    public enum ReviewRole
    {
        Artist,
        Host,
        Venue
    }
}
