using Gigsy2.Core.Entities.Booking;
using Gigsy2.Core.Entities.Common;
using Gigsy2.Core.Entities.Venue;

namespace Gigsy2.Core.Entities.Venue
{
    public class VenueProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public List<string> VenuePhotos { get; set; } = [];
        public List<VenueFacility> Facilities { get; set; } = [];
        public ContactInfo ContactInfo { get; set; } = new ContactInfo();
        // public List<Booking> Bookings { get; set; } = [];
        // public List<VenueReview> Reviews { get; set; } = [];
    }
}
