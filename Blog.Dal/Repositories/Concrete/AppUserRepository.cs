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
        public Task Create(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task Delete(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task Update(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
