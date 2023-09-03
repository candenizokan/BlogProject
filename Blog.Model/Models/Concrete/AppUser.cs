using Blog.Model.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Models.Concrete
{
    public class AppUser:IdentityUser
    {
        private DateTime _createdDate = DateTime.Now;

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        private Statu _statu = Statu.Active;

        public Statu Statu
        {
            get { return _statu; }
            set { _statu = value; }
        }
    }
}
