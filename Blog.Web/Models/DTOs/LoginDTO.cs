using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi Yazınız")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //bu alanı gette gitmek istediği bir yer varsa doldurup göndereceğiz ki posttaki işlemler doğruysa buradaki url üzerinden doğrudan gitmek istediği yere yönlendirelim.

        //aynı kişiyi update ederken id bilgisini postta kullanmak üzere gömmemiz gibi
        public string ReturnUrl { get; set; }
    }
}
