using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Venue;
using Gigsy2.Core.Interfaces;
using Gigsy2.Core.Entities; // Add this using if Gigsy2User is in this namespace
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
            
            profile.gupId = Guid.NewGuid();  // Using gupId as per your convention
            profile.UserId = userId;
            
            var savedProfile = await _artistRepository.AddAsync(profile);
            
            // Update user with reference to gupId
            user.ArtistProfileId = savedProfile.gupId;
            await _userManager.UpdateAsync(user);
            
            return savedProfile;
        }
    }
}