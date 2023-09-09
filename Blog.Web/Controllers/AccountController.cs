﻿using AutoMapper;
using Blog.Model.Models.Concrete;
using Blog.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }
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

                AppUser appUser = _mapper.Map<AppUser>(dto);
            }
            return View(dto);
        }
    }
}
