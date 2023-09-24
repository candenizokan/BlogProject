namespace Blog.Web.Areas.Member.Models.VMs
{
    public class UserDetail
    {
        public string FullName { get; set; }
        public string UserID { get; set; }
        public int AllArticleCount { get; set; }// active + modified +passive article
        public int AllNotPassiveArticleCount { get; set; } // active + modified article
    }
}
