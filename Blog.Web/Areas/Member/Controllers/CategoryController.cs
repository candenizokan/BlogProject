using Blog.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class CategoryController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            
        }
    }
}
