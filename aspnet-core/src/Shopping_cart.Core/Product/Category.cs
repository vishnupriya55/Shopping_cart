using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_cart.Models
{
  public class Category : FullAuditedEntity
  {
    public const int MaxNameLength = 10;
    public const int MaxDescriptionLength = 50;

    [StringLength(MaxNameLength, ErrorMessage = "Name of the product should be min" +
      " 5 characters " +
      "and max 10 characters")]
    public string Name { get; set; }
    [StringLength(MaxDescriptionLength, ErrorMessage = "Name of the product should be min" +
      " 25 characters " +
      "and max 50 characters")]
    public string Description { get; set; }
    public IList<Product> Products { get; set; }

  }
} 
