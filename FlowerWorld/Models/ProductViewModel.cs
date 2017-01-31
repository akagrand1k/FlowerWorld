using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerWorld.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Наименование")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public int? Price { get; set; }

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
    }
}