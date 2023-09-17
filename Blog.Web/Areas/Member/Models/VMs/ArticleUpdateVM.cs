using Blog.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Areas.Member.Models.VMs
{
    public class ArticleUpdateVM
    {
        //Article
        public int ID { get; set; }

        [Required(ErrorMessage = "Başlık Bilgisi Boş Bırakılamaz")]
        [MinLength(2, ErrorMessage = "En az 2 karakter yazmalısınız")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik Bilgisi Boş Bırakılamaz")]
        [MinLength(200, ErrorMessage = "İçerik En az 200 karakter yazmalısınız")]
        public string Content { get; set; }

        [NotMapped] // eşleşme yapma
        [Required(ErrorMessage = "Lütfen Fotoğraf Seçiniz")]
        public IFormFile Image { get; set; }


        //Category
        [Required(ErrorMessage = "Lütfen Kategori Seçiniz")]
        public int CategoryID { get; set; }//seçili olan kategory

        public List<GetCategoryDTO> Categories { get; set; }

        //USER
        [Required]
        public string AppUserID { get; set; }
    }
}
