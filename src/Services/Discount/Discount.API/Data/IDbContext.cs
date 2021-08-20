using System.Data;
using System.Data.Common;

namespace Discount.API.Data
{
    public interface IDbContext
    {
        public IDbConnection DbConnection { get ;  }
    }
}