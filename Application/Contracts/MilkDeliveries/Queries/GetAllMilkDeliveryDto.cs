namespace Application.Contracts.MilkDeliveries.Queries
{
    public class GetAllMilkDeliveryDto
    {
        public int Id { get; set; }
        public float Milk { get; set; }
        public float MilkRate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DailyDevision { get; set; }
        public int StoreId { get; set; }
    }
}
