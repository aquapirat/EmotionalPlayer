using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;

namespace Player.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IPlayerDbContext _context;

        public CreateProductCommandHandler(IPlayerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                ProductName = request.ProductName,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                UnitPrice = request.UnitPrice,
                Discontinued = request.Discontinued
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductId;
        }
    }
}
