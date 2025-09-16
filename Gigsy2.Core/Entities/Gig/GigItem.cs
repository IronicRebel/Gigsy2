using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Gig
{
    public class GigItem
    {
        public Guid gigId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required]
        public Guid VenueId {  get; set; }

    }
}
