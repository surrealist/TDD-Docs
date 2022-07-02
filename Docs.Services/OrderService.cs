using Docs.Models;
using Docs.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Services
{
  public class OrderService : ServiceBase<Order>, IOrderService
  {
    public OrderService(AppDb db) : base(db)
    {
      //
    }

    public string AddDemoOrder()
    {
      var ms = DateTime.Now.Millisecond;

      var o = new Order();
      o.OrderId = $"PO-{ms:0000}";
      o.Date = DateTimeOffset.Now;
      o.CustomerName = "Customer";

      OrderDetail line1 = o.AddItem(
        description: "Blue box",
         salePrice: 100m, quantity: 2);

      OrderDetail line2 = o.AddItem(
        description: "Blue box",
         salePrice: 200m, quantity: 2);

      Add(o);
      SaveChanges();
      return o.OrderId;
    }
  }
}
