using Abp.Application.Services.Dto;

namespace Shopping_cart.Products
{
  public class GetAllProductsInput : PagedResultRequestDto
  {
    public string ProductName { get; set; }
    //public string Description { get; set; }
    //public decimal UpperLimit { get; set; }
    //public decimal LowerLimit { get; set; }
  }
}
