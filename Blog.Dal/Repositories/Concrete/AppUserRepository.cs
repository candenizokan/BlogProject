using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models.Enums;

namespace Blog.Dal.Repositories.Concrete
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ProjectContext _context;
        private readonly UserManager<AppUser> _manager;
        private readonly DbSet<AppUser> _table;
        public AppUserRepository(ProjectContext context,UserManager<AppUser> manager)
        {
            _context = context;
            _manager = manager;
            _table = _context.Set<AppUser>();
        }
        public async Task Create(AppUser appUser)
        {
            await _manager.CreateAsync(appUser,appUser.Password);//identity user olduğu için _manager tarafından çağırıyorum
            await _manager.AddToRoleAsync(appUser, "Member");//kişiyi member olarak ekle

            _context.SaveChanges();
        }

        public async Task Delete(AppUser appUser)
        {
            //Usermanager delete
            appUser.Statu = Statu.Passive;
            await _context.SaveChangesAsync();
        }

        public async Task Update(AppUser appUser)
        {
            
            appUser.Statu = Statu.Modified;
            _table.Update(appUser);
            // userManager update //ileride ihtiyacım olacak şifre değişikliği gibi bir durumda
            await _context.SaveChangesAsync();
        }
    }
}
