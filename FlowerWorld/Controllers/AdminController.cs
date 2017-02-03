using Calabonga.Mvc.PagedListExt;
using FlowerWorld.BL.Service.AuthService;
using FlowerWorld.BL.Service.CategoryService;
using FlowerWorld.BL.Service.ProductService;
using FlowerWorld.DAL;
using FlowerWorld.DAL.Models;
using FlowerWorld.Infrastructure;
using FlowerWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FlowerWorld.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        #region User


        public ActionResult Users()
        {
            AuthViewModel model = new AuthViewModel();
            model.UserList = UserService.FullUserList;
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Users(AuthViewModel model)
        {

            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateUser(AuthViewModel model)
        {
            UserDto dto = new UserDto();
            dto.Id = model.Id;
            dto.UserName = model.UserName;
            dto.Password = model.Password;

            if (ModelState.IsValid)
            {
                UserService.Registration(dto);
                return RedirectToAction("Users", "Admin");
            }
            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            if (id != 0)
            {
                UserService.DeleteUser(id);
                return RedirectToAction("Users", "Admin");
            }
            return View();
        }

        public ActionResult EditUser(int id)
        {
            AuthViewModel model = new AuthViewModel();
            var user = UserService.GetUserById(id);
            model.UserName = user.UserName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(AuthViewModel model)
        {
            UserDto dto = new UserDto();
            dto.Id = model.Id;
            dto.UserName = model.UserName;
            dto.Password = model.Password;

            UserService.EditUser(dto);
            return RedirectToAction("Users", "Admin");
        }
        #endregion

        #region ProductType
        public ActionResult Category()
        {
            CategoryViewModel model = new CategoryViewModel();
            model.CategoryList = CategoryService.FullCategoryList;
            return View(model);
        }

        public ActionResult CreateCategory()
        {
            CategoryViewModel model = new CategoryViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryViewModel model)
        {
            CategoryDto dto = new CategoryDto();
            string imgPath = ImageService.ResizeImage(model.File);
            if (ModelState.IsValid)
            {
                dto.smallPath = ImageService.GetSmallVirPath(imgPath);
                dto.largePath = ImageService.GetLargeVirPath(imgPath);
                dto.CategoryName = model.CategoryName;
                CategoryService.CategoryCreate(dto);
                return RedirectToAction("Category", "Admin");
            }
            return View();
        }

        public ActionResult EditCategory(int id)
        {
            var editModel = CategoryService.GetCategoryById(id);
            CategoryViewModel model = new CategoryViewModel();
            model.CategoryName = editModel.CategoryName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(CategoryViewModel model)
        {
            CategoryDto dto = new CategoryDto();
            if (model!= null)
            {
                dto.Id = model.Id;
                dto.CategoryName = model.CategoryName;
                CategoryService.EditCategory(dto);
            }
            return RedirectToAction("Category", "Admin");

        }

        public ActionResult DeleteCategory(int id)
        {
            CategoryService.DeleteCategory(id);
            return RedirectToAction("Category", "Admin");
        }
        #endregion

        #region Product
        public ActionResult Product(int CategoryId=0,int page=1)
        {
            ProductViewModel model = new ProductViewModel();
            int pageSize = 5;
            model.CurrentFilter = CategoryId;

            List<Product> tList = ProductService.FilterProducts(CategoryId);
            model.ProductList = tList.Skip((page - 1) * pageSize).Take(pageSize);
            model.categoryList = CategoryService.FullCategoryList.ToList();
            model.PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tList.Count };
            return View(model);
        }

        public ActionResult CreateProduct()
        {
            ProductViewModel model = new ProductViewModel();
            model.categoryList = CategoryService.FullCategoryList.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductViewModel model)
        {
            ProductDto dto = new ProductDto();
            var path = ImageService.ResizeImage(model.File);
            if (ModelState.IsValid)
            {
                dto.ProductName = model.ProductName;
                dto.Price = model.Price;
                dto.Description = model.Description;
                dto.CategoryId = model.CategoryId;
                dto.smallPath = ImageService.GetSmallVirPath(path);
                dto.largePath = ImageService.GetLargeVirPath(path);
                ProductService.CreateProduct(dto);
                return RedirectToAction("Product", "Admin");
            }
            return View();
        }

        public ActionResult EditProduct(int id)
        {
            ProductViewModel model = new ProductViewModel();
            var editmodel = ProductService.GetProductById(id);
            
            if (id!= 0)
            {
                model.categoryList = CategoryService.FullCategoryList.ToList();
                model.Id = editmodel.Id;
                model.ProductName = editmodel.ProductName;
                model.Price = editmodel.Price;
                model.CategoryId = editmodel.CategoryId;
                model.Description = editmodel.Description;
            }
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductViewModel model)
        {
            ProductService.EditProduct(model.ProductMapper(model));
            return RedirectToAction("Product", "Admin");
        }

        public ActionResult DeleteProduct(int id)
        {
            ProductService.DeleteProduct(id);
            return RedirectToAction("Product", "Admin");
        }

        #endregion

        #region Orders
        public ActionResult Orders(int page=1)
        {
            OrderViewModel model = new OrderViewModel();
            List <Order> tList = OrderService.NoExecuteOrder.ToList();
            model.OrderList = tList.Skip((page-1)*5).Take(5);
            model.PageInfo = new PageInfo {PageNumber = page,PageSize =5,TotalItems = tList.Count };
            return View(model);
        }

        public ActionResult FinishOrders(int page=1)
        {
            OrderViewModel model = new OrderViewModel();
            List<Order> tList = OrderService.FinishOrders.ToList();
            model.OrderList = tList.Skip((page - 1) * 5).Take(5);
            model.PageInfo = new PageInfo { PageNumber = page, PageSize = 5, TotalItems = tList.Count };
            return View(model);
        }

        public ActionResult ExecuteOrder(int id)
        {
            OrderService.ExecuteOrder(id);
            return RedirectToAction("Orders");
        }

        public ActionResult DeleteOrder(int id)
        {
            OrderService.DeleteOrder(id);
            return RedirectToAction("Orders", "Admin");
        }
        #endregion
    }
}