using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public Task Delete(AppUser appUser)
        {
            appUser.Statu = Model.Models.Enums.Statu.Passive;
            _context.SaveChangesAsync();
        }

        public Task Update(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
