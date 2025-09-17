using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Host;
using Gigsy2.Core.Entities.Venue;

namespace Gigsy2.Core.Entities.Gig
{
    public class GigReview
    {
        [Key]
        public int grId { get; set; }

        [ForeignKey("GigId")]
        public int GigId { get; set; }

        public GigItem GigItem { get; set; }

        public ReviewRole ReviewerRole { get; set; } // Host or Artist
        public int ReviewerId { get; set; }
        public int RevieweeId { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum ReviewRole
    {
        Artist,
        Host,
        Venue
    }

    public enum ReviewType
    {
        Gig,
        Venue,
        Artist
    }
}
