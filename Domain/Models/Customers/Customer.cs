using Domain.Models.Administrators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Customers
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Int64 Mobile { get; set; }
        public string? Address { get; set; }
        public string CustomerType { get; set; }
        [ForeignKey("CreatedByAdmin")]
        public int? CreatedBy { get; set; }
        [ForeignKey("UpdatedByAdmin")]
        public int? UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Profile { get; set; }
        public Admin CreatedByAdmin { get; set; }
        public Admin UpdatedByAdmin { get; set; }

    }
}
