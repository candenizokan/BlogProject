namespace Blog.Model.Models.Concrete
{
    public class Like//BaseEntityden kalıtıma gerek yok. buton sonuçta makaleyi beğeniyorsun. kimsin hangi usersın neyi beğendin makaleye ihtiyacın var. kendine ait datasına geri yok composet key ikiside primary key şeklinde tanımalıyım.
    {

        //NOT=> LIKE SINIFI BaseEntityden kalıtım almaz çünkü 1 beğeni 1 kişi tarafından aynı makaleye 1 kez yapılabilmektedir. Aynı nesne defalarca veritabanına eklenmez. bu yüzden AppUserID ve ArticleID beraber anahtar olmalı ve eşsiz olmalı. SQL tarafından ayrıca id verilerek eşsizlik bozulmamalıdır.


        //kim beğendi appuser
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }


        //neyi beğendi makale
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}