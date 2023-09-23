using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Enums;
using Blog.Web.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public IActionResult Detail(int id)//makale id
        {
            //like ve comment taşımıyorum. dışarıda olmayacak. like comment yapanlar içeridekiler olacak. liken count basacağım

            var article = _articleRepository.GetByDefault
                (
                    selector: a => new ArticleDetailVM()//area dışındaki vm'i kullanmalıyım
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        CreatedDate = a.CreatedDate,
                        Image = a.ImagePath,
                        Content = a.Content,
                        Likes = a.Likes,
                        CategoryID = a.CategoryID,
                        CategoryName = a.Category.Name,
                        UserID = a.AppUserID,
                        UserCreatedDate = a.AppUser.CreatedDate,
                        UserFullName = a.AppUser.FullName,
                        UserImage = a.AppUser.ImagePath

                    },
                    expression: a => a.Statu != Statu.Passive && a.ID == id,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category)
                );
            return View(article);
        }
    }
}
