using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repositories.Concrete
{
    public class AppUserRepository : IAppUserRepository
    {
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
