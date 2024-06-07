using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Customers.Commands
{
    public class UpdateCustomerDto
    {
        public string Name { get; set; }
        public Int64 Mobile { get; set; }
        public string? Address { get; set; }
        public string CustomerType { get; set; }
        public string? ProfileUrl { get; set; }
        public IFormFile? ProfileIcon { get; set; }
        public int UpdatedBy { get; set; }

    }
}
