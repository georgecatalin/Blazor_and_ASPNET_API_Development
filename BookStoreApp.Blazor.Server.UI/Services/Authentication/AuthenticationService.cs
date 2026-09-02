using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient _httpClient;
        public AuthenticationService(IClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public Task<bool> AuthenticateAsync(LoginUserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
