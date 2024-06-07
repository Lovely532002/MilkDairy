using Data.Common;
using Data.Data;
using Domain.Models.Administrators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AdminRepository : EFRepository<Admin>, IAdminRepository
    {
        private readonly DataContext _context;
        public AdminRepository(DataContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
