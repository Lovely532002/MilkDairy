using Data.Common;
using Data.Data;
using Domain.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StoreRepository : EFRepository<MilkStore>, IStoreRepository
    {
        private readonly DataContext _context;
        public StoreRepository(DataContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
