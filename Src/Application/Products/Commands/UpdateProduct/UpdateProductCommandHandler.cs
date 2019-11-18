using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Player.Application.Common.Exceptions;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;

namespace Player.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IPlayerDbContext _context;

        public UpdateProductCommandHandler(IPlayerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.ProductId = request.ProductId;
            entity.ProductName = request.ProductName;
            entity.CategoryId = request.CategoryId;
            entity.SupplierId = request.SupplierId;
            entity.UnitPrice = request.UnitPrice;
            entity.Discontinued = request.Discontinued;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
