namespace Application.Contracts.MilkDeliveries.Commands
{
    public class CreateMilkDeliveryDto
    {
        public float Milk { get; set; }
        public float MilkRate { get; set; }
        public int StoreId { get; set; }
        public string DailyDevision { get; set; }
    }
}
