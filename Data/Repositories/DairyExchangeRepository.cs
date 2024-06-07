using Data.Common;
using Data.Data;
using Domain.Models.DairyExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DairyExchangeRepository : EFRepository<DairyExchange>, IDairyExchangeRepository
    {
        private readonly DataContext _context;
        public DairyExchangeRepository(DataContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
