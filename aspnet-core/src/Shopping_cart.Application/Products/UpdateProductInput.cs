using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Shopping_cart.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Products
{
  [AutoMapTo(typeof(Product))]
  public class UpdateProductInput : IEntityDto
  {

    public const int MaxNameLength = 10;
    public const int MaxDescriptionLength = 50;

    [Required]
    [StringLength(MaxNameLength, ErrorMessage = "Name of the product should be min" +
      " 5 characters " +
      "and max 10 characters")]
    public string Name { get; set; }
    [Required]
    [StringLength(MaxDescriptionLength, ErrorMessage = "Name of the product should be min" +
      " 25 characters " +
      "and max 50 characters")]
    public string Description { get; set; }
    //[System.ComponentModel.DisplayName('Price (Rs.)')]
    public decimal Price { get; set; }
    public int Id { get; set; }
  }
}
