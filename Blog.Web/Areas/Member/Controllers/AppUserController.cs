﻿using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogOut()//kişi yetkilidir. burada [AllowAnonymous] demeye gerek yok. içerdeki kişi dışarı çıkmak istiyor
        {
            _signInManager.SignOutAsync();//_signInManager giriş çıkış işlemlerinde kullanılıyor. bu sınıfa ihtiyacım var di ile almalıyım
            return RedirectToAction("Index", "Home");
        }
    }
}
