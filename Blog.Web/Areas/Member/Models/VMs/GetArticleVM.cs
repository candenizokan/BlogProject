namespace Blog.Web.Areas.Member.Models.VMs
{
    public class GetArticleVM//listeleme sayfasına bunları göstermek istiyorum. serverdan kullanıcıya geliyor. posta düşmeyecek. validasyon kontrolüne gerek yok
    {
        //Article

        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        //Category
        public string CategoryName { get; set; }

        //user
        public string FullName { get; set; }
    }
}
