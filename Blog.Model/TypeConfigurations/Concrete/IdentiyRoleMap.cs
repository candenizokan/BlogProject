using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class IdentiyRoleMap : IEntityTypeConfiguration<IdentityRole>// db ayağa kalkarken member rolünü oluşturmak istiyorum
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole { Id=Guid.NewGuid().ToString(),Name="Member",NormalizedName="MEMBER" });//kayıtlı kullanıcıya bu rolü atıyorum. kullanıcı kayıt olduğunda rolü meber oluyor. daha sonra rol değişikliğini admin yapıyor.
        }
    }
}
