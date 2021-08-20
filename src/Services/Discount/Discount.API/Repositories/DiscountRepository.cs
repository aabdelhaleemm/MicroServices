using System.Threading.Tasks;
using Dapper;
using Discount.API.Data;
using Discount.API.Entities;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IDbContext _dbContext;

        public DiscountRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            var coupon = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<Coupon>(
                @"SELECT * FROM Coupon
                        WHERE ProductName = @ProductName",
                new { productName });
            return coupon ?? new Coupon { Amount = 0, Description = "No Discount Desc", ProductName = "No Discount" };
        }

        public async Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            var affected =
                await _dbContext.DbConnection.ExecuteAsync
                ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                    new { coupon.ProductName, coupon.Description, coupon.Amount });

            return affected != 0;
        }

        public async Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            var affected = await _dbContext.DbConnection.ExecuteAsync
            ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                new
                {
                    coupon.ProductName,
                    coupon.Description,
                    coupon.Amount,
                    coupon.Id
                });

            return affected != 0;
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            var affected = await _dbContext.DbConnection.ExecuteAsync(
                "DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });

            return affected != 0;
        }
    }
}