using Blog.Model.Models.Concrete;
using Blog.Model.TypeConfigurations.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Context
{
    public class ProjectContext : IdentityDbContext<AppUser>
    {
        //connection string ne
        //hangi tablo
        //konfigurasyonların ne

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) //DbContextOptions parametresi alacaksın ve base'ine atana göndereceksin
        {

        }

        //hangi tablo DBSET

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFollewedCategory> UserFollewedCategories { get; set; }

        //konfigurasyonlarım yani tablolar ayağa kalkarken neye göre kalksın. maplerimi göndereceğim

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new ArticleMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new LikeMap());
            builder.ApplyConfiguration(new UserFollewedCategoryMap());
            builder.ApplyConfiguration(new IdentiyRoleMap());


            base.OnModelCreating(builder);
        }

    }
}
