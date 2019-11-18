using MediatR;

namespace Player.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
