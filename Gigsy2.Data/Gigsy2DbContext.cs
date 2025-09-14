using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Gigsy2.Data.Entities.User;

namespace Gigsy2.Data
{
    public class Gigsy2DbContext(DbContextOptions<Gigsy2DbContext> options) : IdentityDbContext<Gigsy2User>(options)
    {

    }
}
