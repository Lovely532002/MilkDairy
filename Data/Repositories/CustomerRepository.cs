using Data.Common;
using Data.Data;
using Domain.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
