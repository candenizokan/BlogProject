using Blog.Model.Models.Concrete;
using System.Collections.Generic;
using System;

namespace Blog.Web.Models.VMs
{
    public class ArticleDetailVM
    {
        //Article
        public int ArticleID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Like> Likes { get; set; }


        //Category

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //APPuser

        public string UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserImage { get; set; }
        public DateTime UserCreatedDate { get; set; }
    }
}
