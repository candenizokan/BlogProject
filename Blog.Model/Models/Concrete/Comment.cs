using Blog.Model.Models.Abstract;

namespace Blog.Model.Models.Concrete
{
    public class Comment : BaseEntity
    {

        public string Text { get; set; }

        //navigation prop

        //1 yorum 1 kişinindir. ////appuser nesnesi ve yazar appuser tutmam lazım
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        //1 yorum 1 makaleye aittir.//Article nesnesi ve Article tutmam lazım
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}