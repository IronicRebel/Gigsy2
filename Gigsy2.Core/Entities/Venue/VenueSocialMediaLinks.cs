using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Venue
{
    public class VenueSocialMediaLinks
    {
        public Guid Id { get; set; }
        public Guid VenueProfileLuId { get; set; }

        // Venue-specific platforms
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? LinkedIn { get; set; }
        public string? Mixcloud { get; set; }
        public string? RA { get; set; }
        public string? SoundCloud {  get; set; }
        public string? TikTok { get; set; }
        public string? X { get; set; }
        public string? YouTube { get; set; }

    }
}
