namespace Application.Contracts.Stores.Commands
{
    public class UpdateMilkStoreDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
