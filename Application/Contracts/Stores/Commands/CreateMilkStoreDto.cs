namespace Application.Contracts.Stores.Commands
{
    public class CreateMilkStoreDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CreatedBy { get; set; }

    }
}
