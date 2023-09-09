using Microsoft.AspNetCore.Http;

namespace Blog.Web.Models.DTOs
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
    }
}
