using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Blog.Web.Areas.Member.Models.DTOs;
using Blog.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Blog.Model.Models.Enums;
using Blog.Dal.Repositories.Concrete;
using AutoMapper;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class ArticleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryRepository _cRepo;
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleController(UserManager<AppUser> userManager, ICategoryRepository cRepo, IArticleRepository articleRepository, IMapper mapper)
        {
            _userManager = userManager;
            _cRepo = cRepo;
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Create()
        {
            //içerdeki kişiyi bulayım. user managera ihtiyacım var . di ile alacağım
            AppUser appUser = await _userManager.GetUserAsync(User);

            //articlecreate vm oluştur
            ArticleCreateVM vm = new ArticleCreateVM()
            {
                AppUserID = appUser.Id,
                Categories = _cRepo.GetByDefaults
                (
                    selector: a=> new GetCategoryDTO { ID = a.ID,Name=a.Name},
                    expression : a=> a.Statu != Statu.Passive
                )
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                //ArticleCreateVM nesnesi var Article çıkart diyeceğim. bunu mappers ile söylemem lazım. bir mapleme daha var. kaynak ArticleCreateVM varış noktam article nesnem. ctoda IMapperada ihtiyacım var şimdi 

                var article = _mapper.Map<Article>(vm); //mapperın yapamadığı fotoğraf var. fotoğrafı alıp okuyup article'a atamam lazım. kişiyi kayıt ederken kullanmıştık


                Guid guid = Guid.NewGuid();
                var image = Image.Load(vm.Image.OpenReadStream());//dosyayı okudum
                image.Mutate(a => a.Resize(70, 70));//şekillendir
                image.Save($"wwwroot/images/{guid}.jpg");//dosya kaydedildi

                //makalenin fotoğrafı nerede kayıtlı
                article.ImagePath = $"/images/{guid}.jpg";

                _articleRepository.Create(article);

                return RedirectToAction("List");
            }
            //negatif senaryo
            vm.Categories = _cRepo.GetByDefaults
                (
                    selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name },
                    expression: a => a.Statu != Statu.Passive
                );
            return View(vm);
        }

        public async Task<IActionResult> List()
        {
           

            //içerideki kişi bul usermanager ile
            AppUser appUser = await _userManager.GetUserAsync(User);//içerde oturumu açılmış kim olduğu bilinen kişi


            //listelerken doğrudan article nesnesini yollamayacağım. listeleme sayfası üzerinden edit yada delete yapıyorum. uzun content bilgisine ihtiyacım yok. title foto bilgisi id arka planda tutarım oluşturucusunu gösteririrm. detay için detail sayfası yaparım orada ne varsa her şeyi gösteririrm.
            // madem herkesi göndermiyorum propertylerine karar vermem lazım. bir vm nesnesi oluşturmaml lazım gerarticlevm

            var list = _articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleVM()
                    {
                        ArticleID = a.ID,
                        CategoryName = a.Category.Name,
                        FullName = a.AppUser.FullName,
                        Title = a.Title,
                        Image = a.ImagePath
                    },
                    expression: a => a.Statu != Statu.Passive && a.AppUserID == appUser.Id,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category)
                );
           
            return View(list);
        }

        public IActionResult Update(int id)
        {
            //hangi article yakalamam lazım. içerdekilerin idsi hangisi eşleşirse benimkiyle onu getir

            Article article = _articleRepository.GetDefault(a=>a.ID==id);//article update vm oluşturmam lazım. buradan sonra oraya gideceğim

            var updatedArticle = _mapper.Map<ArticleUpdateVM>(article);

            return View();
        }
    }
}
