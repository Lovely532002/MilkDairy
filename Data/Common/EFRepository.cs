using Ardalis.Specification.EntityFrameworkCore;
using Data.Data;
using Domain.Common;

namespace Data.Common
{
    public class EFRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EFRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
