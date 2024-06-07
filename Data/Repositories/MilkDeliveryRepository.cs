using Data.Common;
using Data.Data;
using Domain.Models.MilkDeliveries;

namespace Data.Repositories
{
    public class MilkDeliveryRepository : EFRepository<MilkDelivery>,IMilkDeliveryRepository
    {
        private readonly DataContext _context;
        public MilkDeliveryRepository(DataContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
