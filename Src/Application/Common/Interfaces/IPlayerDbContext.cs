using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Player.Domain.Entities;

namespace Player.Application.Common.Interfaces
{
    public interface IPlayerDbContext
    {
        public DbSet<Song> Songs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
