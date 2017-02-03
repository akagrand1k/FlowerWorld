using FlowerWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerWorld.Controllers
{
    public class CatalogController : BaseController
    {
        
        public ActionResult Index()
        {
            CategoryViewModel model = new CategoryViewModel();
            model.CategoryList = CategoryService.FullCategoryList.ToList();
            return View(model);
        }

        public ActionResult ProductItem(int typeId,int minPrice=0,int maxPrice=0)
        {
            ProductViewModel model = new ProductViewModel();

            model.ProductList = ProductService.FilterProducts(typeId, minPrice, maxPrice);
            return View(model);
        }


        [HttpGet]
        public ActionResult OrderSend(int ProductId)
        {
            OrderViewModel model = new OrderViewModel();
            model.ProductId = ProductId;
            return PartialView("OrderSend");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderSend(OrderViewModel model)
        {
            var dto = model.MappDto(model);
            OrderService.SendOrder(dto);
            return RedirectToAction("Index", "Catalog");
        }

        

        public ActionResult SearchProduct(string searchCritery)
        {
            ProductViewModel model = new ProductViewModel();
            
            model.ProductList = ProductService.SearchProducts(searchCritery);
            return View(model);
        }
    }
}