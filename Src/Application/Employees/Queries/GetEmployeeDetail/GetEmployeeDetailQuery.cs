using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Player.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Player.Application.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDetailVm>
    {
        public int Id { get; set; }

        public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailVm>
        {
            private readonly IPlayerDbContext _context;
            private readonly IMapper _mapper;

            public GetEmployeeDetailQueryHandler(IPlayerDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<EmployeeDetailVm> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Employees
                    .Where(e => e.EmployeeId == request.Id)
                    .ProjectTo<EmployeeDetailVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
