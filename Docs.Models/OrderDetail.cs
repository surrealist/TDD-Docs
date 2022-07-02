using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Models
{
  public class OrderDetail
  {

    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int LineId { get; set; } = 1;
    [Key]
    [Column(Order = 1)]
    public int OrderId { get; set; }

    public string Description { get; set; } = "";

    public decimal SalePrice { get; set; } // vat inclusion
    public int Quantity { get; set; }

    public float VatPercent { get; set; } = 7.0f;
    
    public decimal TotalAmount 
      => SalePrice * Quantity;

    public decimal NetAmount
      => Math.Round(TotalAmount * 100.0m / (100.0m + (decimal)VatPercent), 
        2, MidpointRounding.AwayFromZero);

    public decimal VatAmount
      => TotalAmount - NetAmount;

    [Required]
    public virtual Order Order { get; set; }
  }
}
