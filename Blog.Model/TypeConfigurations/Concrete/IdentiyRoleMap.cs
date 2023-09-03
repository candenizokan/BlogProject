using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class IdentiyRoleMap: IEntityTypeConfiguration<IdentityRole>// db ayağa kalkarken member rolünü oluşturmak istiyorum
    {
    }
}
