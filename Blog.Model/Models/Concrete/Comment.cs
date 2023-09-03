using Blog.Model.Models.Abstract;

namespace Blog.Model.Models.Concrete
{
    public class Comment : BaseEntity
    {

        public string Text { get; set; }

        //navigation prop
    }
}