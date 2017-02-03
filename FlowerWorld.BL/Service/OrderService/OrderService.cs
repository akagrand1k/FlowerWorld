using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using FlowerWorld.DAL.Models;
using FlowerWorld.DAL.Repository;
using FlowerWorld.DAL;

namespace FlowerWorld.BL.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> orderRepository;
        public OrderService(IRepository<Order> orderRepo)
        {
            orderRepository = orderRepo;
        }
        public IEnumerable<Order> FullOrderList
        {
            get
            {
                return orderRepository.Get.Include(x => x.Product);
            }
        }

        public IEnumerable<Order> FinishOrders
        {
            get
            {
                return orderRepository.Get.Include(x => x.Product).Where(x => x.IsDone == true);
            }
        }

        public IEnumerable<Order> NoExecuteOrder
        {
            get
            {
                return orderRepository.Get.Include(x => x.Product).Where(x => x.IsDone == false);
            }
        }

        public void DeleteOrder(int id)
        {
            orderRepository.Delete(id);
        }
        
        public void SendOrder(OrderDto dto)
        {
            Order entity = new Order();
            entity.CustomerName = dto.CustomerName;
            entity.CusmomerPhone = dto.CusmomerPhone;
            entity.DateOrder = DateTime.Now; ;
            entity.DesciptionOrder = dto.DesciptionOrder;
            entity.DateCreate = DateTime.Now;
            entity.DateUpdate = DateTime.Now;
            entity.ProductId = dto.ProductId;
            entity.IsDone = false;
            orderRepository.Add(entity);
        }

        public void ExecuteOrder(int id)
        {
            var entity = orderRepository.GetById(id);
            if (entity != null)
            {
                entity.IsDone = true;
                orderRepository.Update(entity);
            }
        }
    }
}