using Domain.Models.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DairyExchange
{
    public class DairyExchange
    {
        [Key]
        public int Id { get; set; }
        public float Milk { get; set; }
        public float MilkRate { get; set; }
        public string DailyDevision { get; set; }
        public DateTime Date {  get; set; }= DateTime.Now;
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
