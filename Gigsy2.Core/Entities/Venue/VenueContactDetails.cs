using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Gigsy2.Core.Entities.Common;

namespace Gigsy2.Core.Entities.Venue
{
    public class VenueContactDetails : ContactInfo
    {
        [Key]
        public Guid vcdId { get; set; } // Primary key for VenueContactDetails
        public Guid VenueProfileLuId { get; set; } // Foreign key to link with VenueProfile

        // Additional venue-specific contact properties can be added here in the future

        // Address properties to match data from Google Places API / Address input helper
            // 'location',
            // 'locality',
            // 'administrative_area_level_1',
            // 'postal_code',
            // 'country'
        public string? AddressLocation { get; set; } // Full address
        public string? AddressLocality { get; set; } // City or locality
        public string? AddressAdministrativeAreaLevel1 { get; set; } // State or province
        public string? AddressPostalCode { get; set; } // Postal code
        public string? AddressRegion { get; set;
        } // Region (if applicable)
        public string? AddressCountry { get; set; } // Country

        // Location coordinates for mapping, "nearby" etc
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

    }


}
