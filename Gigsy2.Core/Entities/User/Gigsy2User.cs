using Microsoft.AspNetCore.Identity;
using System;

namespace Gigsy2.Core.Entities.User
{
    public class Gigsy2User : IdentityUser
    {
        public Guid Gigsy2UserId { get; set; }

        // Basic user profile information
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Profile references
        public Guid? apLUId { get; set; }
        public Guid? vpLUId { get; set; }
        
        // User preferences
        public bool ReceiveNotifications { get; set; } = true;
        public string PreferredLanguage { get; set; } = "en-US";
        public string TimeZone { get; set; } = "UTC";

        // Helper properties (must be properties, not fields)
        // public string DisplayName => $"{FirstName} {LastName}";
        // public bool IsArtist => apLUId.HasValue;
        // public bool IsVenueManager => vpLUId.HasValue;
        // public bool IsEventHost => false;
    }
}
