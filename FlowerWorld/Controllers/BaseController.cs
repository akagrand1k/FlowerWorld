using FlowerWorld.App_Start;
using FlowerWorld.BL.Service.AuthService;
using FlowerWorld.BL.Service.CategoryService;
using FlowerWorld.BL.Service.OrderService;
using FlowerWorld.BL.Service.ProductService;
using FlowerWorld.DAL.Models;
using FlowerWorld.DAL.Repository;
using FlowerWorld.Infrastructure;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerWorld.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IRepository<Product> prodRepo { get; set; }
        
        [Inject]
        public IRepository<Category> categRepo { get; set; }

        [Inject]
        public IRepository<Order> orderRepo { get; set; }

        [Inject]
        public IRepository<User> UserRepo { get; set; }
        
        // Service
        [Inject]
        public IUserService UserService { get; set; }
       
        [Inject]
        public ICategoryService CategoryService { get; set; }
        
        [Inject]
        public IImageService ImageService { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IOrderService OrderService { get; set; }

        public BaseController()
        {            
            NinjectWebCommon.Kernel.Inject(this);
        }
    }
}