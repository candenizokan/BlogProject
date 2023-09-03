using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class ArticleMap : IEntityTypeConfiguration<Article>//Article için db configurasyonu
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired(true);

            //navigation prop


            //category
            //article kendi içerisinde bir tane kategori nesnesi taşır---1 kategorinin çokça makalesi var---bunlar bağlıdır categoryid
            builder.HasOne(a=>a.Category).WithMany(a=>a.Articles).HasForeignKey(a=>a.CategoryID).OnDelete(DeleteBehavior.Restrict);

            //user
            //1 makalenin bir userı var. bir userin çokça makalesi vardır
            builder.HasOne(a => a.AppUser).WithMany(a => a.Articles).HasForeignKey(a => a.AppUserID).OnDelete(DeleteBehavior.Restrict);

            /*
             
                DeleteBehavior--> silinme davranışı. MicEfcore gelen bir enum yapısıdır. İlişkili entitylerde silinme durumunda nasıl dacranılacağına karar verilmesini sağlar.

                //Restrict=> ebeveyn-çocuk ilişkisi(parent-child) yani ebeveynsiz çocuk olmaması gibi category silinmeye çalışıldığında makale kategorisiz kalacağı için müsade etmez.
                
                //No Action=> ilişkilerde silinmeyi serbest bırakır hata vermez, bir şey yapmaz.

                //Casdade => evebeyn-çocuk ilişkisibnde ebeveyn silindiğinde ona bağlı çocuklarıda siler

                //Setnull => defaulttaki silinme daranışıdır. FK(foreign key) boş geçilebilmesini sağlar. (northwinddeki product-kategory gibi)

             */

        }
    }
}
