using MediatR;

namespace Player.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListVm>
    {
    }
}
