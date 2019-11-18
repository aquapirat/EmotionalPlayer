using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Player.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Player.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListVm>
    {
        private readonly IPlayerDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IPlayerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomersListVm> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CustomersListVm
            {
                Customers = customers
            };

            return vm;
        }
    }
}
