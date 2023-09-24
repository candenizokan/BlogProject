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
        private readonly ILikeRepository _likeRepository;

        public ArticleController(UserManager<AppUser> userManager, ICategoryRepository cRepo, IArticleRepository articleRepository, IMapper mapper, ILikeRepository likeRepository)
        {
            _userManager = userManager;
            _cRepo = cRepo;
            _articleRepository = articleRepository;
            _mapper = mapper;
            _likeRepository = likeRepository;
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
                    selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name },
                    expression: a => a.Statu != Statu.Passive
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

            Article article = _articleRepository.GetDefault(a => a.ID == id);//article update vm oluşturmam lazım. buradan sonra oraya gideceğim

            var updatedArticle = _mapper.Map<ArticleUpdateVM>(article);

            updatedArticle.Categories = _cRepo.GetByDefaults
                (
                    selector: a => new GetCategoryDTO() { ID = a.ID, Name = a.Name },
                    expression: a => a.Statu != Statu.Passive
                );

            return View(updatedArticle);
        }

        [HttpPost]
        public IActionResult Update(ArticleUpdateVM vm)
        {
            //toDo : kayıtlı kullanıcı login olduktan sonra içerideki bir başka kişinin makalesini güncelleyememeli
            if (ModelState.IsValid)
            {
                var article = _mapper.Map<Article>(vm);
                using var image = Image.Load(vm.Image.OpenReadStream());
                image.Mutate(a => a.Resize(70, 70));

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpeg");

                article.ImagePath = $"/images/{guid}.jpeg";
                _articleRepository.Update(article);
                return RedirectToAction("List");

            }
            return View(vm);

            //toDo:: negatşf senaryoda yani validasyon kontroleri gerçekleşmezse categories ?? cshtmlde sorun olur.

            //toDo: makale fotoğrafını güncellemezse ? eski fotoğraf kullanıcıya sunulması istenirse güncellenmeli

            //toDo: fotoğrafı güncellerse bu makaleye ait eski fotoğraf wwwroot altından silinmeli ve yerine yenisi eklenmeli
        }

        public IActionResult Delete(int id)
        {
            //article yakala
            Article article = _articleRepository.GetDefault(a => a.ID == id);
            //article repo içindeki metodu çağır elimdeki budur pasive çek,
            _articleRepository.Delete(article);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Detail(int id)
        {
            //appuser var
            AppUser appUser = await _userManager.GetUserAsync(User);//içeri giriş yapmış kullanıcı


            //articledetailvm oluşmalı.

            var article = _articleRepository.GetByDefault
                (
                    selector: a=> new ArticleDetailVM() 
                    { 
                        ArticleID = a.ID,
                        Title=a.Title,
                        CreatedDate = a.CreatedDate,
                        Image = a.ImagePath,
                        Content=a.Content,
                        Likes=a.Likes,
                        CategoryID = a.CategoryID,
                        CategoryName=a.Category.Name,
                        UserID=a.AppUserID,
                        UserCreatedDate = a.AppUser.CreatedDate,
                        UserFullName = a.AppUser.FullName,
                        UserImage = a.AppUser.ImagePath,
                        AppUserID = appUser.Id

                    },
                    expression: a=>a.Statu!=Statu.Passive && a.ID==id,
                    include:a=>a.Include(a=>a.AppUser).Include(a=>a.Category)
                );
            return View(article);
        }
        //unlike yazarken id adlı parametre göndereceğim makalenin idsi olacak o
        public async Task<IActionResult> Like(int id)
        {
            Article article = _articleRepository.GetDefault(a => a.ID == id);//ilgili makaleyi yakaladım

            AppUser appUser = await _userManager.GetUserAsync(User);//login olan kullanıcıyı bulabiliyorum

            Like like = new Like() { ArticleID=id, Article=article, AppUser = appUser, AppUserID=appUser.Id};// like nesnesi oluştur. hangi makaleyi khangi kişi başında set et. bu like'ı oluşturacağım ihtiyacım var like repoya şimdi onu oluşturacağım article controllerda like repoya ihtiyacım var. DI ile alacağım ilikerepo ver diyeceğim like repo verecek

            _likeRepository.Create(like);

            return RedirectToAction("Detail", new {id=id});//detailde kullanmış olduğum paramete =id =>Detail(int id) oraya atayacağım id buradaki like'ın id si. //burada detail actionuna gönderdiğimiz parametre değişkeninin adı neyse elimizdeki makaleid yi atıyoruz çünkü Detail sayfası makaleID siz çalışmaz
        }

        public async Task<IActionResult> UnLike(int id)
        {
            Article article = _articleRepository.GetDefault(a => a.ID == id); // İlgili makaleyi yakala

            AppUser appUser = await _userManager.GetUserAsync(User); // Giriş yapmış kullanıcıyı bulun

            // Kullanıcının daha önce bu makaleyi beğenip beğenmediğini kontrol edin
            //Like unlike = _likeRepository.GetDefault(article.ID,appUser.Id);
            Like like = _likeRepository.GetDefault(a=>a.AppUserID==appUser.Id && a.ArticleID==article.ID);

            if (like != null)
            {
                // Eğer kullanıcı daha önce beğenmişse, beğeniyi kaldırın
                _likeRepository.Delete(like);
            }

            return RedirectToAction("Detail", new { id = id }); // Detail sayfasına geri dönün
        }
    }
}
