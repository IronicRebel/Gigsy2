using Gigsy2.Core.Entities.Booking;
using Gigsy2.Core.Entities.Performance;
using System;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Services
{
    public class PerformanceService
    {
        // This would be called by a background job or trigger
        public PerformanceItem CreatePerformanceFromCompletedBooking(BookingItem booking)
        {
            // Validate booking is complete (date has passed)
            if (booking.EventDate.Date > DateTime.Today)
            {
                throw new InvalidOperationException("Cannot create performance from future booking");
            }

            // Create performance record
            var performance = new PerformanceItem
            {
                Id = Guid.NewGuid(),
                BookingId = booking.Id,  // Link back to original booking
                ArtistId = booking.ArtistId,
                VenueId = booking.VenueId,
                PerformanceDate = booking.EventDate,
                StartTime = booking.StartTime,
                Duration = booking.EndTime - booking.StartTime,
                Title = booking.DisplayTitle ?? $"Performance at {booking.DisplayVenueName}",
                Status = PerformanceStatus.Completed
            };

            return performance;
        }
    }
}