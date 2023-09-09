﻿using AutoMapper;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Blog.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _userRepo;

        public AccountController(IMapper mapper, IAppUserRepository userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
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

                var image = Image.Load(dto.Image.OpenReadStream());//dosyayı okudum
                image.Mutate(a => a.Resize(70, 70));
                image.Save();
            }
            return View(dto);
        }
    }
}
