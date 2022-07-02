using System.ComponentModel.DataAnnotations;

namespace Docs.Models
{
  public class Order
  {

    public string OrderId { get; set; } = "PO-0000";

    public DateTimeOffset Date { get; set; }

    [StringLength(200)]
    public string CustomerName { get; set; } = "";

    public virtual ICollection<OrderDetail> LineItems { get; set; } = new HashSet<OrderDetail>();

    public decimal TotalAmount => LineItems.Sum(x => x.TotalAmount);

    public OrderDetail AddItem(string description, decimal salePrice, int quantity)
    {
      var line = new OrderDetail();

      line.LineId = LineItems.Count + 1;
      line.Description = description;
      line.SalePrice = salePrice;
      line.Quantity = quantity;

      LineItems.Add(line);
      return line;
    }
  }
}