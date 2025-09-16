using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistSocialMediaLinks
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ArtistProfileLuId")]
        public ArtistProfile? ArtistProfile { get; set; }

        // Artist-specific platforms
        public string? AppleMusic { get; set; }
        public string? Bandcamp { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? LinkedIn { get; set; }
        public string? Mixcloud { get; set; }
        public string? RA {  get; set; }
        public string? Spotify { get; set; }
        public string? SoundCloud { get; set; }
        public string? TikTok { get; set; }
        public string? X { get; set; }
        public string? YouTube { get; set; }

    }
}
