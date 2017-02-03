using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.BL.Service.OrderService
{
    public interface IOrderService
    {
        IEnumerable<Order> FullOrderList { get; }
        IEnumerable<Order> FinishOrders { get; }
        IEnumerable<Order> NoExecuteOrder { get; }
        void  ExecuteOrder(int id);
        void SendOrder(OrderDto dto);
        void DeleteOrder(int id);
    }
}