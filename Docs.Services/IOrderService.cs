using Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Services
{
  public interface IOrderService : IService<Order>
  {
    string AddDemoOrder();
  }
}
