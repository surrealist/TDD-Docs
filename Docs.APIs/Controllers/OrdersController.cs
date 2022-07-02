using Docs.Models;
using Docs.Services;
using Docs.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Docs.APIs.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private readonly IOrderService orders;

    public OrdersController(IOrderService orders)
    {
      this.orders = orders;
    }

    [HttpGet]
    public ActionResult<string> Test()
    {
      var orderId = orders.AddDemoOrder();
      return orderId;
    }
  }
}
