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

        private readonly Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();
        private readonly Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();
        private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();
        private readonly Dictionary<int, Shipper> Shippers = new Dictionary<int, Shipper>();
        private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();

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