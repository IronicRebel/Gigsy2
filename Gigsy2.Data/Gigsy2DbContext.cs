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

        #region Initialise DbSets
        /////////////////////////////////////////////
        
        public DbSet<ArtistProfile> ArtistProfiles { get; set; } = null!;
        public DbSet<VenueProfile> VenueProfiles { get; set; } = null!;
        public DbSet<BookingItem> Bookings { get; set; } = null!;
        public DbSet<ArtistSocialMediaLinks> ArtistSocialMediaLinks { get; set; } = null!;
        public DbSet<ArtistReviews> ArtistReviews { get; set; } = null!;
        public DbSet<ArtistAvailability> ArtistAvailabilities { get; set; } = null!;

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure lookup ID indices
            
            #region Configure Relationships

            //
            // Artist
            //

            // Profile
            builder.Entity<ArtistProfile>()
                .HasOne<Gigsy2User>()
                .WithOne()
                .HasForeignKey<ArtistProfile>("gupLUId")
                .IsRequired(false);
                
            builder.Entity<ArtistSocialMediaLinks>()
                .HasOne<ArtistProfile>()
                .WithOne()
                .HasForeignKey<ArtistSocialMediaLinks>("ArtistProfileId");

            builder.Entity<ArtistProfile>()
                .HasOne(a => a.ArtistAvailability)
                .WithOne(a => a.ArtistProfile)
                .HasForeignKey<ArtistAvailability>(a => a.ArtistAvailabilityId);

            //
            // Venue
            //

            // Profile 
            builder.Entity<VenueProfile>()
                .HasIndex(v => v.gupId)    // Index on lookup ID, not primary key
                .IsUnique();

            // Profile



            #endregion Configure Relationships
        }
    }
}
