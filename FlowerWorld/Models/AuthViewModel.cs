using FlowerWorld.BL.Service.AuthService;
using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlowerWorld.Models
{
    public class AuthViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string returnUrl { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        
        public IEnumerable<User> UserList { get; set; }

        public bool CountCheck()
        {
            if (UserList.Count() == 0) return true;
            else return false;
        }
    }
}