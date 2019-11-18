using MediatR;

namespace Player.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    {
    }
}
