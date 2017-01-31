using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerWorld.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование категории")]
        public string CategoryName { get; set; }

        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }

        public IEnumerable<Category> CategoryList { get; set; }

        public bool CountCheck()
        {
            if (CategoryList.Count() == 0) return true;
            else return false;
        }
    }
}