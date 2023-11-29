using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices;

public class DiscountGrpcservice
{
  private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

  public DiscountGrpcservice(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
  {
    _discountProtoServiceClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient));
  }

  public async Task<CouponModel> GetDiscount(string productName)
  {
    var discountRequest = new GetDiscountRequest { ProductName = productName };
    return await _discountProtoServiceClient.GetDiscountAsync(discountRequest);
  }
}
