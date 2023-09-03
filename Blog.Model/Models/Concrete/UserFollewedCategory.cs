namespace Blog.Model.Models.Concrete
{
    public class UserFollewedCategory
    {
        //Bu somof ara tablo sınıfıdır. buradaki id ler hem foreign key hem primary key yani composite key olacaktır. Bu yüzden bir kez daha BaseEntityden kalıtım almasına gerek yoktur


        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}