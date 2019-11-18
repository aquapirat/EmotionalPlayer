using AutoMapper;
using MediatR;
using Player.Application.Common.Exceptions;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Player.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVm>
    {
        private readonly IPlayerDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandler(IPlayerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return _mapper.Map<CustomerDetailVm>(entity);
        }
    }
}
