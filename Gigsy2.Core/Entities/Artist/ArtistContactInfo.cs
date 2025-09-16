using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Artist
{
    public class ArtistContactInfo
    {
        public Guid ArtistContactInfoId { get; set; }
        public Guid ArtistProfileId { get; set; }

        [EmailAddress]
        public string? ArtistEmail { get; set; }

        [Phone]
        public string? ArtistPhoneNumber { get; set; }

        [Url]
        public string? ArtistWebsiteUrl { get; set; }
    }
}
