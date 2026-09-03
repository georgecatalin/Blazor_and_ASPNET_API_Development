using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._localStorage = localStorage;
        }
        public async Task<bool> AuthenticateAsync(LoginUserDTO userDTO )
        {
            try
            {
               var response = await _httpClient.LoginAsync(userDTO);

               if( response is null || string.IsNullOrEmpty(response.Token))
                {
                    return false;
                }

                //Store token
                await _localStorage.SetItemAsync("authenticationToken", response.Token);

                //Change authentication state of application



                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
