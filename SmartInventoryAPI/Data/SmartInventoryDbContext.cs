using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartInventoryAPI.Data;

public class SmartInventoryDbContext:IdentityDbContext<ApplicationUser>
{
    public SmartInventoryDbContext(DbContextOptions<SmartInventoryDbContext> options):base(options)
    {
        
    }
}