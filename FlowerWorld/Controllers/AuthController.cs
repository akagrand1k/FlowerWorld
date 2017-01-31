using FlowerWorld.BL.Service.AuthService;
using FlowerWorld.DAL;
using FlowerWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FlowerWorld.Controllers
{
    public class AuthController : BaseController
    {
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            AuthViewModel model = new AuthViewModel();
            return View(model);
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthViewModel model)
        {
            UserDto dto = new UserDto();
            dto.Id = model.Id;
            dto.UserName = model.UserName;
            dto.Password = model.Password;

            var user = UserService.Authentication(dto);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (Url.IsLocalUrl(model.returnUrl))
                    return Redirect(model.returnUrl);
                else
                    return RedirectToAction("Index", "Admin");
            }
            else
                ModelState.AddModelError("", "Неправильный логин или пароль");
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Auth");
        }
    }
}