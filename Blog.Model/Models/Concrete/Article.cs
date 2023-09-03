using Blog.Model.Models.Abstract;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model.Models.Concrete
{
    public class Article: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }

        //navigationProp

        //1 makalenin 1 yazarı


        //1 makalenin çokça beğenisi


        //1 makalenin çokça yorumu


        //1 makalenin 1 kategorisi
    }
}