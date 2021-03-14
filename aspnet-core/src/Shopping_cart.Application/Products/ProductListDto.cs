using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Shopping_cart.Models;
using System;

namespace Shopping_cart.Products
{
  [AutoMapFrom(typeof(Product))]
  public class ProductListDto : IEntityDto
  {
    public string Name { get; set; }
    public string Price { get; set; }
    public int Id { get; set; }
  }
}
