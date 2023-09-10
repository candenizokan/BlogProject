using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Member.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        //createte hangisini açtıysam update de de aynını açmalıyım

        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        [MinLength(2, ErrorMessage = "En az 2 karakter yazmalısınız")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        [MinLength(10, ErrorMessage = "En az 10 karakter yazmalısınız")]
        public string Description { get; set; }

        public int ID { get; set; }
        //posta düştüğümde kimin güncelleyeceğimi bilmesi için ID si muhakkak olmalı
    }
}
