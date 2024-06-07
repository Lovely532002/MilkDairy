using Domain.Models.Stores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.MilkDeliveries
{
    public class MilkDelivery
    {
        [Key]
        public int Id { get; set; }
        public float Milk { get; set; }
        public float MilkRate { get; set; }
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
        public string DailyDevision { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public MilkStore Store { get; set; }
    }
}
