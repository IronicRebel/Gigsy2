using Gigsy2.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Performance
{
    public class PerformanceItem
    {
        
            public Guid Id { get; set; }
            public Guid BookingId { get; set; }
            public Guid ArtistId { get; set; }
            public Guid VenueId { get; set; }
            public DateTime PerformanceDate { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan Duration { get; set; }
            public List<Genre>? Genres { get; set; } 
            public List<EventType>? EventTypes { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public PerformanceStatus Status { get; set; }

            // Review-related properties
            public bool CanBeReviewed => Status == PerformanceStatus.Completed;
            public List<PerformanceReview> Reviews { get; set; } = new();
        }

        public enum PerformanceStatus
        {
            Scheduled,
            Canceled,
            Completed,
            Postponed
        }
    }
