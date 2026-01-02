using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorRegistroUsuarios.Data.Models;

namespace BlazorRegistroUsuarios.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private AuthenticationState _currentUser;

        public CustomAuthStateProvider()
        {
            _currentUser = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async Task UpdateAuthenticationState(UsuarioRegistrador usuario)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Permiso)
            }, "apiauth");

            _currentUser = new AuthenticationState(new ClaimsPrincipal(identity));
            NotifyAuthenticationStateChanged(Task.FromResult(_currentUser));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(_currentUser);
        }
    }
}