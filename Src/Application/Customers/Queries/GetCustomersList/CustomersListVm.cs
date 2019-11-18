using System.Collections.Generic;

namespace Player.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public IList<CustomerLookupDto> Customers { get; set; }
    }
}
