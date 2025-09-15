namespace Gigsy2.Core.Entities.Booking
{
    public class BookingItem
    {
        public Guid Id { get; set; }
        public Guid ArtistId { get; set; }
        public Guid VenueId { get; set; }
        public string DisplayTitle { get; set; } = String.Empty;
        public string DisplayVenueName { get; set; } = String.Empty;
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Fee { get; set; }
        // public string Requirements { get; set; }
        // public BookingStatus Status { get; set; }
        // public PaymentStatus PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
