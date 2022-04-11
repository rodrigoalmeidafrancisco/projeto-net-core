using Blazored.LocalStorage;
using BlazorWebAssemblyAuthentication.Client.Providers;
using BlazorWebAssemblyAuthentication.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorWebAssemblyAuthentication.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var loginJson = JsonSerializer.Serialize(loginModel);
            var response = await _httpClient.PostAsync("api/login", new StringContent(loginJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAuthenticated(loginModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var registerJson = JsonSerializer.Serialize(registerModel);
            var response = await _httpClient.PostAsync("api/accounts", new StringContent(registerJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<RegisterResult>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return loginResult;
        }
    }
}
