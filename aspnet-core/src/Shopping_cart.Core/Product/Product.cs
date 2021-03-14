using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Shopping_cart.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_cart.Models
{
  public class Product : CreationAuditedEntity
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
    public virtual Category ProductCategory { get; set; }
  }
}
