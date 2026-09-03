using BookStoreApp.API.Models.User;

namespace BookStoreApp.API.Controllers
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public AuthResponse UserDetails { get; set; }
    }
}