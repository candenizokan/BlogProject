﻿using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class AppUserMap: IEntityTypeConfiguration<AppUser>//AppUser için config yapıyorum
    {
    }
}
