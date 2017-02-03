using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerWorld.Models
{
    public class CategoryViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование категории")]
        public string CategoryName { get; set; }
        public string relPath { get; set; }

        [Required]
        [Display(Name = "Выберите файл")]
        public HttpPostedFileBase File { get; set; }
        
        public IEnumerable<Category> CategoryList { get; set; }

        public bool CountCheck()
        {
            if (CategoryList.Count() == 0) return true;
            else return false;
        }
    }
}