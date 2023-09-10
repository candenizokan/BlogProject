using AutoMapper;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Blog.Web.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _userRepo;
        private readonly SignInManager<AppUser> _signInManager;//girişi çıkış işlemleri için çalışıyor
        private readonly UserManager<AppUser> _userManager;//şifre değiştirme gibi bazı işlemleri kullanmak için

        public AccountController(IMapper mapper, IAppUserRepository userRepo, UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (ModelState.IsValid)// validasyonlarım tamam mı
            {
                //aoutomapperdan destek alacağım

                AppUser appUser = _mapper.Map<AppUser>(dto);

                var image = Image.Load(dto.Image.OpenReadStream());//dosyayı okudum
                image.Mutate(a => a.Resize(70, 70));
                image.Save($"wwwroot/images/{appUser.UserName}.jpg");//dosya kaydedildi

                appUser.ImagePath = $"/images/{appUser.UserName}.jpg";//kaydettiğim yer

                await _userRepo.Create(appUser);

                return RedirectToAction("Login");//kayıttan sonra login ister

            }
            return View(dto);
        }

        public IActionResult LogIn(string returnUrl)// kişinin ulaşmak istediği sayfa
        {
            return View(new LoginDTO() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {//appuser aslında identiy user kişisi
                // kullanıcıyı bulması için userManager sınıfına ihtiyacım var. bir sınıfta başka bir sınıfa ihtiyyaç duyuyorum bunuda di ile almam gerekiyor
                AppUser appUser = await _userManager.FindByEmailAsync(dto.Email); //içerde böyle bir appuse kişisi var mı
                if (appUser!=null)
                {
                    //şifre kotrolü yapmam lazım. bunu başka bir sınıf yapıyor. bu durumda bunu di ile almam lazım.
                    SignInResult result = await _signInManager.PasswordSignInAsync(appUser.UserName, dto.Password, false, false);
                }
            }
            return View(dto);
        }
    }
}
