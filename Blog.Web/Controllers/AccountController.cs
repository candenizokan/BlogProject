﻿using Blog.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO dto)
        {
            if (ModelState.IsValid)// validasyonlarım tamam mı
            {
                //aoutomapperdan destek alacağım
            }
            return View(dto);
        }
    }
}
