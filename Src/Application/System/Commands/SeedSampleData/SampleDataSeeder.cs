using Microsoft.EntityFrameworkCore;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Player.Persistence
{
    public class SampleDataSeeder
    {
        private readonly IPlayerDbContext _context;
        private readonly IUserManager _userManager;

        // Data to seed
        // private readonly Dictionary<int, Song> Songs = new Dictionary<int, Song>();

        public SampleDataSeeder(IPlayerDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {

        }
    }
}