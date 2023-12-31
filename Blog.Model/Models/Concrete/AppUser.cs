﻿using Blog.Model.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model.Models.Concrete
{
    public class AppUser:IdentityUser
    {

        public AppUser()
        {
            //kullanıcıyı newlerken listler null gelecek. ben bununla uğraşmamak için ilk baştan boş sepetleri oluşturuyorum.
            //eğer bir sınıf kendi içerisinde çokça elemanlar barındırıyorsa ctorda list yapısnı oluşturmam lazım
            //app user ilk geldiğinde adamın makalesi yok yorumu yok hiç bir şeyi yok. bunları doldurmam için bu yapıların oluşması lazım
            Articles = new List<Article>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
            UserFollewedCategories = new List<UserFollewedCategory>();
        }
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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName =>$"{FirstName} {LastName}";
        public string Password { get; set; }
        public string ImagePath { get; set; }//kişi fotoğrafının kaynağı
        
        [NotMapped]//bu alanı kolon olrak veritabanı tarafında işaretleme
        public IFormFile Image { get; set; }//fotoğrafı çekip almaya, okumaya, atamaya çalışacak ama db de olmayacak


        //navigation property


        //1 kullanıcının  çokça makalesi olabilir.
        public List<Article> Articles { get; set; }


        //1 kullanıcının takip ettiği çokça kategori olabilir.

        public List<UserFollewedCategory> UserFollewedCategories { get; set; }

        //1 kullanıcının çokça yorumu olabilir.

        public List<Comment> Comments { get; set; }

        //1 kullanıcının çokça beğenisi olabilir.
        public List<Like> Likes { get; set; }
    }
}
