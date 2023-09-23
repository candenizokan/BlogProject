using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Detail(int id)//makale id
        {
            return View();
        }
    }
}
