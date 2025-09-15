using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistSocialMediaLinks
    {
        public Guid Id { get; set; }
        public Guid ArtistProfileId { get; set; }

        // Artist-specific platforms
        public string? SoundCloud { get; set; }
        public string? Instagram { get; set; }
        public string? X { get; set; }
        public string? Facebook { get; set; }
        public string? LinkedIn { get; set; }
        public string? Mixcloud { get; set; }
        public string? YouTube { get; set; }
        public string? Spotify { get; set; }
        public string? AppleMusic { get; set; }
        public string? Bandcamp { get; set; }
        public string? Website { get; set; }

    }
}
