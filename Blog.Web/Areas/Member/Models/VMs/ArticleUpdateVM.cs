using Blog.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Areas.Member.Models.VMs
{
    public class ArticleUpdateVM
    {
        //Article
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }


        //Category

        public int CategoryID { get; set; }//seçili olan kategory

        public List<GetCategoryDTO> Categories { get; set; }

        //USER

        public string AppUserID { get; set; }
    }
}
