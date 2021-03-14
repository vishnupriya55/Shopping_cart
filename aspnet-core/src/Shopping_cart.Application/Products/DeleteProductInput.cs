using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Shopping_cart.Models;

namespace Shopping_cart.Products
{

  [AutoMapTo(typeof(Product))]
  public class DeleteProductInput
  {
    public int Id { get; set; }
  }
}
