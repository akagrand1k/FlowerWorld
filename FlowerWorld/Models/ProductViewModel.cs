using FlowerWorld.BL.Service.ProductService;
using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerWorld.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Наименование")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public int? Price { get; set; }

        
        public int? minPrice { get; set; }
        
        public int? maxPrice { get; set; }

        [Required]
        [Display(Name ="Описание продукта")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public string smallPath { get; set; }
        public string largePath { get; set; }

        [Required]
        [Display(Name ="Выберите файл")]
        public HttpPostedFileBase File { get; set; }

        public IEnumerable<Product> ProductList { get; set; }
        public List<Category> categoryList { get; set; }// initialize for dropdownlist
        
        public PageInfo PageInfo { get; set; }
        public int CurrentFilter { get; set; }
        public int typeId { get; set; }

        public bool CountCheck()
        {
            if (ProductList.Count() == 0) return true;
            else return false;
        }

        [Display(Name ="Категория продукта")]
        public IEnumerable<SelectListItem> SelectListCategory
        {
            get
            {
                foreach (var category in categoryList)
                {
                    yield return new SelectListItem { Value = category.Id.ToString()
                        , Text = category.CategoryName };
                }
            }
        }

        public  ProductDto ProductMapper(ProductViewModel model)
        {
            return new ProductDto
            {
                Id = model.Id,
                ProductName = model.ProductName,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Description = model.Description
            };
        }

        public ProductViewModel DtoMapper(ProductDto dto)
        {
            return new ProductViewModel
            {
                Id = dto.Id,
                ProductName = dto.ProductName,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                Description = dto.Description
            };
        }
    }
}