using Blog.Model.Models.Abstract;
using System.Collections.Generic;

namespace Blog.Model.Models.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation Prop

        //1 kategorinin çokça makalesi olabilir
        public List<Article> Articles { get; set; }

        //1 kategoriyi takip eden çokça kişi olabilir.//usera direkt gidemiyorum ara tabloya gitmem lazım
        public List<UserFollewedCategory> UserFollewedCategories { get; set; }
    }
}