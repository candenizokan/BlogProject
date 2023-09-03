using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Context
{
    public class ProjectContext:IdentityDbContext<AppUser>
    {
    }
}
