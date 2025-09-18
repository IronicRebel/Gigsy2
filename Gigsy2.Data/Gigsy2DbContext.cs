using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Common;
using Gigsy2.Core.Entities.Gig;
using Gigsy2.Core.Entities.User;
using Gigsy2.Core.Entities.Venue;
using Gigsy2.Core.Entities.Host;

namespace Gigsy2.Data
{
    public class Gigsy2DbContext : IdentityDbContext<Gigsy2User>
    {
        public Gigsy2DbContext(DbContextOptions<Gigsy2DbContext> options) : base(options)
        {
        }

        /// 
        /// // INITIALISE DBSETs BELOW
        ///

        #region Initialise DbSets

        // Artist
        public DbSet<ArtistProfile> ArtistProfiles { get; set; } = null!;
        public DbSet<ArtistContactInfo> ArtistContactInfos { get; set; } = null!;
        public DbSet<ArtistGenres> ArtistGenres { get; set; } = null!;
        public DbSet<ArtistSocialMediaLinks> ArtistSocialMediaLinks { get; set; } = null!;

        // Common
        public DbSet<EventType> EventTypes { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
       

        // Gig
        public DbSet<GigApplication> GigApplications { get; set; } = null!;
        public DbSet<GigItem> GigItems { get; set; } = null!;
        public DbSet<GigReview> GigReviews { get; set; } = null!;

        // Host
        public DbSet<HostProfile> HostProfiles { get; set; } = null!;

        public DbSet<VenueProfile> VenueProfiles { get; set; } = null!;

        #endregion


        /// 
        /// // ON MODEL CREATING BELOW
        ///

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

            // Contact Details
            builder.Entity<ArtistProfile>().HasOne<ArtistContactInfo>()
                .WithOne()
                .HasForeignKey<ArtistContactInfo>("ArtistProfileId");


            // Artist Genres
            builder.Entity<ArtistProfile>()
                .HasMany<ArtistGenres>();

            // Social Media Handles
            builder.Entity<ArtistProfile>()
                .HasMany<ArtistSocialMediaLinks>()
                .WithOne()
                .HasForeignKey<ArtistSocialMediaLinks>("ArtistProfileLuId");

            //
            // Gig
            //
            builder.Entity<GigItem>()
                .HasOne<VenueProfile>()
                .WithMany()
                .HasForeignKey("VenueProfileId")
                .IsRequired();
            builder.Entity<GigItem>()
                .HasOne<EventType>()
                .WithMany()
                .HasForeignKey("EventTypeId")
                .IsRequired(false);
            builder.Entity<GigItem>()
                .HasMany<GigApplication>()
                .WithOne()
                .HasForeignKey("GigId")
                .IsRequired(false);
            builder.Entity<GigItem>()
                .HasMany<GigReview>()
                .WithOne()
                .HasForeignKey("GigId")
                .IsRequired(false);


            // 
            // Host
            //

            // Profile
            builder.Entity<HostProfile>()
                .HasOne<Gigsy2User>()
                .WithOne()
                .HasForeignKey<HostProfile>("gupLUId")
                .IsRequired(false);

            // Contact Details

            //
            // Venue
            //

            // Profile 
            builder.Entity<VenueProfile>()
                .HasIndex(v => v.gupId)    // Index on lookup ID, not primary key
                .IsUnique();

            // Contact Details

            // Facilities

            // Venue Social Media Links

            

            
            #endregion Configure Relationships
        }
    }
}
