using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Venue;
using Gigsy2.Core.Entities.User;
using Gigsy2.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Gigsy2.Core.Services
{
    public class ProfileManagementService
    {
        private readonly UserManager<Gigsy2User> _userManager;
        private readonly IRepository<ArtistProfile> _artistRepository;
        private readonly IRepository<VenueProfile> _venueRepository;
        
        public ProfileManagementService(
            UserManager<Gigsy2User> userManager,
            IRepository<ArtistProfile> artistRepository,
            IRepository<VenueProfile> venueRepository)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
            _venueRepository = venueRepository ?? throw new ArgumentNullException(nameof(venueRepository));
        }
        
        public async Task<ArtistProfile> CreateArtistProfileAsync(string userId, ArtistProfile profile)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new ArgumentException("User not found");
            
            // Set primary key
            profile.Id = Guid.NewGuid();
            
            // Set lookup ID to match user's gupId
            profile.Gigsy2UserIdLookup = user.Id;
            
            // Set timestamps
            profile.CreatedAt = DateTime.UtcNow;
            profile.UpdatedAt = DateTime.UtcNow;
            
            // Save profile
            var savedProfile = await _artistRepository.AddAsync(profile);
            
            // Update user with reference to artist profile
            user.apLUId = savedProfile.Id; // This should point to the profile's primary key
            await _userManager.UpdateAsync(user);
            
            return savedProfile;
        }
        
        public async Task<VenueProfile> CreateVenueProfileAsync(string userId, VenueProfile profile)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new ArgumentException("User not found");
            
            // Generate new GUID for linking to user profile
            profile.gupId = Guid.NewGuid();
            profile.CreatedAt = DateTime.UtcNow;
            profile.UpdatedAt = DateTime.UtcNow;
            
            // Save the profile
            var savedProfile = await _venueRepository.AddAsync(profile);
            
            // Update user with reference to the venue profile's GUID
            user.vpLUId = savedProfile.gupId;  // Using the correct property name
            await _userManager.UpdateAsync(user);
            
            return savedProfile;
        }
        
        public async Task<bool> DeleteArtistProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null || !user.apLUId.HasValue) return false;
            
            // Find the profile by its primary key
            var profile = await _artistRepository.GetByIdAsync(user.apLUId.Value);
            if (profile == null) return false;
            
            // Delete profile
            await _artistRepository.DeleteAsync(profile);
            
            // Clear reference
            user.apLUId = null;
            await _userManager.UpdateAsync(user);
            
            return true;
        }
    }
}