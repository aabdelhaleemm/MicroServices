using System.Threading.Tasks;
using Discount.gRPC.Protos;
using Microsoft.Extensions.Logging;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;
        private readonly ILogger<DiscountGrpcService> _logger;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService,
            ILogger<DiscountGrpcService> logger)
        {
            _discountProtoService = discountProtoService;
            _logger = logger;
        }

        public async Task<CouponModel> GetDiscountAsync(string productName)
        {
            _logger.LogInformation($"Consuming GRPC product name {productName}");
            return await _discountProtoService.GetDiscountAsync(new GetDiscountRequest { ProductName = productName });
        }
    }
}