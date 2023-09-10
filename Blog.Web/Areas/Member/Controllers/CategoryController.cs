using AutoMapper;
using Blog.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {

            }
            return View(dto);
        }
    }
}
