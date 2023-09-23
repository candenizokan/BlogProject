﻿using System;

namespace Blog.Web.Models.VMs
{
    public class GetArticleVM
    {


        public string Title { get; set; }

        public string Content { get; set; }

        public int ArticleID { get; set; }


        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }

        public string AppUserID { get; set; }

        public string CategoryName { get; set; }

        public string UserFullName { get; set; }
    }
}
