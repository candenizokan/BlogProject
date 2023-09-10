using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Member.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        [MinLength(2, ErrorMessage = "En az 2 karakter yazmalısınız")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        [MinLength(10, ErrorMessage = "En az 10 karakter yazmalısınız")]
        public string Description { get; set; }
    }
}
