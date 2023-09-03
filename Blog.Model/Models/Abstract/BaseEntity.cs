using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        private DateTime _createDate=DateTime.Now;

        public DateTime CreateDate
        {
            get { return _createDate=DateTime.Now; }
            set { _createDate = value; }
        }

    }
}
