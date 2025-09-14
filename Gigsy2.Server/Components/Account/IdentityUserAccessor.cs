using Gigsy2.Data;
using Gigsy2.Data.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Gigsy2.Server.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<Gigsy2User> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<Gigsy2User> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
