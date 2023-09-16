using Blog.Model.Models.Concrete;
using Blog.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Blog.Web.Areas.Member.Models.VMs
{
    public class ArticleCreateVM
    {
        //ARTICLE
        public string Title { get; set; }
        public string Content { get; set; }


        public IFormFile Image { get; set; }


        //CATEGORY
        public int CategoryID { get; set; }
        public List<GetCategoryDTO> Categories { get; set; }

        //Appuser
        public string AppUserID { get; set; }
    }
}
