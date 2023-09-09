using AutoMapper;
using Blog.Model.Models.Concrete;
using Blog.Web.Models.DTOs;

namespace Blog.Web.Models.AutoMappers
{
    public class Mappers:Profile
    {
        public Mappers()
        {
            //mapplemeler

            CreateMap<RegisterDTO, AppUser>();//sen bana registerDTO dan bir appuser nesnesi teslim etmelisin
        }
    }
}
