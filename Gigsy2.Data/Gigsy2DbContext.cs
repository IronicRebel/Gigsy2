using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Booking;
using Gigsy2.Core.Entities.User;
using Gigsy2.Core.Entities.Venue;

namespace Gigsy2.Data
{
    public class Gigsy2DbContext : IdentityDbContext<Gigsy2User>
    {
        public Gigsy2DbContext(DbContextOptions<Gigsy2DbContext> options) : base(options)
        {
        }

        // Properly initialized DbSet properties
        public DbSet<ArtistProfile> ArtistProfiles { get; set; } = null!;
        public DbSet<VenueProfile> VenueProfiles { get; set; } = null!;
        public DbSet<BookingItem> Bookings { get; set; } = null!;
        public DbSet<ArtistSocialMediaLinks> ArtistSocialMediaLinks { get; set; } = null!;
        public DbSet<ArtistReview> ArtistReviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure lookup ID indices
            builder.Entity<ArtistProfile>()
                .HasIndex(a => a.gupLUId)  // Index on lookup ID, not primary key
                .IsUnique();

            builder.Entity<VenueProfile>()
                .HasIndex(v => v.gupId)    // Index on lookup ID, not primary key
                .IsUnique();

            // Configure relationships
            builder.Entity<ArtistProfile>()
                .HasOne<Gigsy2User>()
                .WithOne()
                .HasForeignKey<ArtistProfile>("gupLUId")
                .IsRequired(false);
                
            builder.Entity<ArtistSocialMediaLinks>()
                .HasOne<ArtistProfile>()
                .WithOne()
                .HasForeignKey<ArtistSocialMediaLinks>("ArtistProfileId");
        }
    }
}
