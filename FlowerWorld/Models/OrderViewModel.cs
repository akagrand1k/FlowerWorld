using FlowerWorld.BL.Service.OrderService;
using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerWorld.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Имя")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string CusmomerPhone { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string DesciptionOrder { get; set; }

        public int ProductId { get; set; }
        public bool Execute { get; set; }

        public IEnumerable<Order> OrderList { get; set; }
        public PageInfo PageInfo { get; set; }

        public OrderDto MappDto(OrderViewModel model)
        {
            return new OrderDto
            {
                CustomerName = model.CustomerName,
                CusmomerPhone = model.CusmomerPhone,
                DesciptionOrder = model.DesciptionOrder,
                ProductId = model.ProductId
            };
        }

        public bool CountCheck()
        {
            if (OrderList.Count() == 0) return true;
            else return false;
        }
    }
}