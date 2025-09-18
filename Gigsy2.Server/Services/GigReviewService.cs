using Gigsy2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Gigsy2.Core.Entities.Artist;
using Gigsy2.Core.Entities.Gig;

namespace Gigsy2.Core.Entities.Gig
{
    public class GigReviewService
    {
        private readonly Gigsy2DbContext _context;

        public GigReviewService(Gigsy2DbContext context)
        {
            _context = context;
        }

        public async Task<List<GigReview>> GetReviewsWithDetailsAsync(Guid gigId)
        {
            var reviews = await _context.GigReviews
                .Where(r => r.GigId == gigId)
                .ToListAsync();

            foreach (var review in reviews)
            {
                review.ReviewerDisplayName = await GetDisplayNameAsync(
                    review.ReviewerRole, review.ReviewerId);

                review.RevieweeDisplayName = await GetDisplayNameAsync(
                    review.RevieweeRole, review.RevieweeId);
            }

            return reviews;
        }

        private async Task<string> GetDisplayNameAsync(ReviewRole role, int userId)
        {
            // Example logic—adapt based on your schema
            return role switch
            {
                ReviewRole.Artist => await _context.Artists
                    .Where(a => a.Id == userId)
                    .Select(a => a.DisplayName)
                    .FirstOrDefaultAsync(),

                ReviewRole.Host => await _context.Hosts
                    .Where(h => h.Id == userId)
                    .Select(h => h.DisplayName)
                    .FirstOrDefaultAsync(),

                _ => "Unknown"
            };
        }
    }
}
