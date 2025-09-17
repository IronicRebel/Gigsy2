using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Common;

namespace Gigsy2.Core.Entities.Gig
{
    public class GigApplication
    {
        public Guid gaId { get; set; }
        public Guid GigId { get; set; }
        public GigItem? GigItem { get; set; }

        public Guid ArtistId { get; set; }
        public ArtistProfile? ArtistProfile { get; set; }

        public ApplicationStatus Status { get; set; } // Pending, Accepted, Rejected
        public DateTime SubmittedAt { get; set; }
        public DateTime? RespondedAt { get; set; }
        public string? Message { get; set; } // Optional message from artist


    }

    public enum ApplicationStatus
    {
        Pending,
        Accepted,
        Rejected,
        Withdrawn
    }
}
