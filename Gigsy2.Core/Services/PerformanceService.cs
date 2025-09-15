using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigsy2.Core.Entities.Booking;
using Gigsy2.Core.Entities.Performance;
using static Gigsy2.Core.Entities.Performance.PerformanceItem;

namespace Gigsy2.Core.Services
{
    public class PerformanceService
    {
        // This would be called by a background job or trigger
        public Performance CreatePerformanceFromCompletedBooking(BookingItem booking)
        {
            // Validate booking is complete (date has passed)
            if (booking.EventDate.Date > DateTime.Today)
            {
                throw new InvalidOperationException("Cannot create performance from future booking");
            }

            // Create performance record
            var performance = new Performance
            {
                Id = Guid.NewGuid(),
                BookingId = booking.Id,  // Link back to original booking
                ArtistId = booking.ArtistId,
                VenueId = booking.VenueId,
                PerformanceDate = booking.EventDate,
                StartTime = booking.StartTime,
                Duration = booking.EndTime - booking.StartTime,
                Title = booking.Title ?? $"Performance at {booking.VenueName}",
                Description = booking.Description,
                Status = PerformanceStatus.Completed
            };

            return performance;
        }
    }
}