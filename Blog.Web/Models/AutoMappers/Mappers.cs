using AutoMapper;
using Blog.Model.Models.Concrete;
using Blog.Web.Areas.Member.Models.DTOs;
using Blog.Web.Areas.Member.Models.VMs;
using Blog.Web.Models.DTOs;

namespace Blog.Web.Models.AutoMappers
{
    public class Mappers:Profile
    {
        public Mappers()
        {
            //mapplemeler

            CreateMap<RegisterDTO, AppUser>();//sen bana registerDTO dan bir appuser nesnesi teslim etmelisin
            CreateMap<CreateCategoryDTO, Category>();//CreateCategoryDTO dan category nesnesi istiyorum
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();//çift yönlü çalışacak
            CreateMap<ArticleCreateVM, Article>();
        }
    }
}
