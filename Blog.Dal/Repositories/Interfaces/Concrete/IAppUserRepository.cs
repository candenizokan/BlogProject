using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repositories.Interfaces.Concrete
{
    public interface IAppUserRepository
    {
        //usermanagera ben iş yaptıracağım o yüzden void create metod yazamıyorum. usermanager sınıfı asnkron çalışıyor o yüzden task yazıyorum
        Task Create(AppUser appUser);
        Task Delete(AppUser appUser);
        Task Update(AppUser appUser);
    }
}
