using Blog.Model.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        private DateTime _createdDate = DateTime.Now;

        public DateTime CreatedDate
        {
            get { return _createdDate = DateTime.Now; }
            set { _createdDate = value; }
        }

        private Statu _statu=Statu.Active;

        public Statu Statu
        {
            get { return _statu; }
            set { _statu = value; }
        }

    }
}
