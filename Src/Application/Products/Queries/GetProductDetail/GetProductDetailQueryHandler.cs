using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Player.Application.Common.Exceptions;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Player.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : MediatR.IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IPlayerDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IPlayerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Products
                .ProjectTo<ProductDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.ProductId == request.Id, cancellationToken);

            if (vm == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return vm;
        }
    }
}
