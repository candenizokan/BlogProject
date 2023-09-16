using Blog.Model.Models.Concrete;
using Blog.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Areas.Member.Models.VMs
{
    public class ArticleCreateVM
    {
        //ARTICLE
        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        [MinLength(2, ErrorMessage = "En az 2 karakter yazmalısınız")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bu alan Boş Bırakılamaz")]
        [MinLength(200, ErrorMessage = "En az 200 karakter yazmalısınız")]
        public string Content { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Lütfen Fotoğraf Seçiniz")]
        public IFormFile Image { get; set; }


        //CATEGORY
        [Required(ErrorMessage = "Lütfen Kategori Seçiniz")]
        public int CategoryID { get; set; }
        public List<GetCategoryDTO> Categories { get; set; }

        //Appuser
        [Required]
        public string AppUserID { get; set; }
    }
}
