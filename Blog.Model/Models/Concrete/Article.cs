using Blog.Model.Models.Abstract;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model.Models.Concrete
{
    public class Article: BaseEntity
    {
        //likelerın ve yorumların boş koleksiyon yapılarını oluşturmam lazım ki çalışma zamanında hata almayayım
        public Article()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }

        //navigationProp

        //1 makalenin 1 yazarı
        //yazar nesnesi ve yazar id tutmam lazım
        public string AppUserID { get; set; }//IdentityUser id sini GUID alacağımız için string olacak tuttul
        public AppUser AppUser { get; set; }

        //1 makalenin çokça beğenisi
        public List<Like> Likes { get; set; }

        //1 makalenin çokça yorumu
        public List<Comment> Comments { get; set; }

        //1 makalenin 1 kategorisi////kategori nesnesi ve kategori id tutmam lazım
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}