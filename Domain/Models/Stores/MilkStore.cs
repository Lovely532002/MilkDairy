using Domain.Models.Administrators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Stores
{
    public class MilkStore
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [ForeignKey("Created_ByAdmin")]
        public int? CreatedBy { get; set; }
        [ForeignKey("Updated_ByAdmin")]
        public int? UpdatedBy { get; set; }
        public Admin Created_ByAdmin { get; set; }
        public Admin Updated_ByAdmin { get; set; }


    }
}
