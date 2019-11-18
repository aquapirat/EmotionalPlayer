using Microsoft.EntityFrameworkCore;

namespace Player.Persistence
{
    public class PlayerDbContextFactory : DesignTimeDbContextFactoryBase<PlayerDbContext>
    {
        protected override PlayerDbContext CreateNewInstance(DbContextOptions<PlayerDbContext> options)
        {
            return new PlayerDbContext(options);
        }
    }
}
