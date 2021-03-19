using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_cart.Models
{
  public class Order
  {
    public int Id { get; set; }
    public string Customer { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product PurchasedProduct { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
  }
}
