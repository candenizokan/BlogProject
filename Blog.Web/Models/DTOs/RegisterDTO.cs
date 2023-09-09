using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [NotMapped]     //bu property mapleme, eşleştirme yapma !
        public IFormFile Image { get; set; }
    }
}
