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

        public CategoryController(IMapper mapper,ICategoryRepository categoryRepository,UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
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

        public IActionResult List()
        {
            //view bag ile ara tabloya(UserFollewedCategories) git app user ıd ile eşleşenleri getir diyeceğim. buna bir repo yazmam gerekecek. unfollowda nesneyi uçurmam lazım. ara tablo elemanlarının hepsini getirecek ve silecek actiona ihtiyacım var. repolar context ile konuşarak gerçekleştirdik şimdiye kadar. yine aynısını yapmam lazım. katmanlı mimaride contexte gidemem. ilk önce interface oluşturacağım sonra concrete. ara tablo nesneleri base entityden kalıtım almıyor. metodlarını ortak bir yere yazmama gerek yok. baseden kalıtım alanlar gibi davranmayacak.
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
    }
}
