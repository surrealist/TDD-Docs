using System;
using Xunit;

namespace Docs.Models.Tests
{
  public class OrderTest
  {
    public class AddItem
    {
      [Fact]
      public void Basic()
      {
        var o = new Order();
        o.OrderId = "PO-0001";
        o.Date = DateTimeOffset.Now;
        o.CustomerName = "Customer";

        OrderDetail line1 = o.AddItem(
          description: "Blue box", 
           salePrice: 100m, quantity: 2);

        Assert.NotNull(line1); 

        Assert.Equal("Blue box", line1.Description);
        Assert.Equal(100m, line1.SalePrice);
        Assert.Equal(2, line1.Quantity);
        Assert.Equal(7.0f, line1.VatPercent);
        Assert.Equal(200m, line1.TotalAmount);
        Assert.Equal(186.92m, line1.NetAmount);
        Assert.Equal(13.08m, line1.VatAmount);
        Assert.Equal(1, line1.LineId);

        Assert.Single(o.LineItems);

        Assert.Equal(200m, o.TotalAmount);
      }

      [Fact]
      public void TwoLineItems_LineIdAreSequential()
      {
        var o = new Order();
        o.OrderId = "PO-0001";
        o.Date = DateTimeOffset.Now;
        o.CustomerName = "Customer";

        OrderDetail line1 = o.AddItem(
          description: "Blue box",
           salePrice: 100m, quantity: 2);

        OrderDetail line2 = o.AddItem(
          description: "Blue box",
           salePrice: 200m, quantity: 2);

        Assert.NotNull(line1); 
        Assert.NotNull(line2);
        Assert.Equal(1, line1.LineId);
        Assert.Equal(2, line2.LineId);

      }
    }

  }
}