using Domain.Models.Customers;
using Domain.Models.Stores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Administrators
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Profile { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [InverseProperty("CreatedByAdmin")]
        public List<Customer> CreatedCustomers { get; set; }

        [InverseProperty("UpdatedByAdmin")]
        public List<Customer> UpdatedCustomers { get; set; }
        [InverseProperty("Created_ByAdmin")]
        public List<MilkStore> CreatedMilkStores { get; set; }
        [InverseProperty("Updated_ByAdmin")]
        public List<MilkStore> UpdatedMilkStores { get; set; }

    }
}
