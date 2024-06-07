namespace Application.Contracts.Customers.Queries
{
    public class GetAllCustomersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Int64 Mobile { get; set; }
        public string? Address { get; set; }
        public string CustomerType { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Profile { get; set; }
    }
}
