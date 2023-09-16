using AutoMapper;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Blog.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserFollewedCategoryRepository _userCateRepo;

        public CategoryController(IMapper mapper,ICategoryRepository categoryRepository,UserManager<AppUser> userManager, IUserFollewedCategoryRepository userCateRepo)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _userCateRepo = userCateRepo;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)//CreateCategoryDTO dto nesnesi çıkartacağım
        {
            if (ModelState.IsValid)
            {
                //categori nesnesi istiyorum bunu mapper verecek. bir mapleme yapalım
                Category category = _mapper.Map<Category>(dto);
                _categoryRepository.Create(category);
                return RedirectToAction("List");
            }
            return View(dto);
        }

        public async Task<IActionResult> List()
        {
            //view bag ile ara tabloya(UserFollewedCategories) git app user ıd ile eşleşenleri getir diyeceğim. buna bir repo yazmam gerekecek. unfollowda nesneyi uçurmam lazım. ara tablo elemanlarının hepsini getirecek ve silecek actiona ihtiyacım var. repolar context ile konuşarak gerçekleştirdik şimdiye kadar. yine aynısını yapmam lazım. katmanlı mimaride contexte gidemem. ilk önce interface oluşturacağım sonra concrete. ara tablo nesneleri base entityden kalıtım almıyor. metodlarını ortak bir yere yazmama gerek yok. baseden kalıtım alanlar gibi davranmayacak.IUserFollewedCategoryRepository soyut isteyim somut alacğım di ile startupa gidip yazmayıda atlamıyorum

            //içerideki kişi bul usermanager ile
            AppUser appUser = await _userManager.GetUserAsync(User);//içerde oturumu açılmış kim olduğu bilinen kişi

            ViewBag.list = _userCateRepo.GetFollowedCategories(a => a.AppUserID == appUser.Id); // ara tablonun metod kütüphanesi. senin GetFollowedCategories metodun var aldığın expression dahilinde ara tablo elemanlarını getir diyorsun. böylelikle kendi takip ettiklerimi almış oldum.

            var list = _categoryRepository.GetDefaults(a => a.Statu != Statu.Passive);
            return View(list);
        }

        public IActionResult Update(int id)
        {
            //kimi güncelleyeceğim
            Category category = _categoryRepository.GetDefault(a=>a.ID==id);
            //karşı tarafa tamamını açmam. DTO ile mapleyip onu viewda paylaşacağım

            UpdateCategoryDTO dto = _mapper.Map<UpdateCategoryDTO>(category);
            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                //categori nesnesi istiyorum bunu mapper verecek. bir mapleme yapalım
                Category category = _mapper.Map<Category>(dto);
                _categoryRepository.Update(category);
                return RedirectToAction("List");
            }
            return View(dto);
        }


        public async Task<IActionResult> Follow(int id)
        {
            //kimi takip edeceğim
            Category category = _categoryRepository.GetDefault(a => a.ID == id);

            AppUser appUser = await _userManager.GetUserAsync(User); //user managera ihticım var bu sınıftan ilgili kişiyi yakalayacağım. asyn çalışıyor. git userı getir dedim 

            //aratablo elemanını oluşturup ya kategori ya appuser üzerinden ekleyeceğim

            category.UserFollewedCategories.Add
                (
                    new UserFollewedCategory() 
                    { CategoryID=id,Category=category,AppUser=appUser,AppUserID=appUser.Id}
                );
            _categoryRepository.Update(category);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> UnFollow(int id)
        {
            AppUser appUser = await _userManager.GetUserAsync(User);//kişimi bul
            //bana şu ara tablo elemanını getir bu nesneye veriyor olman lazım. delete çağırmadan çmce tek bir useCategoryfollowed nesnesini almam laım. tekrar repolarımı gideceğim
        }
    }
}
