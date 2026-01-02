using BlazorRegistroUsuarios.Data.Models;

namespace BlazorRegistroUsuarios.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioRegistrador?> ObtenerPorIdAsync(int id);
        Task<List<UsuarioRegistrador>> ObtenerTodosAsync();
        Task<bool> CrearAsync(UsuarioRegistrador usuario);
        Task<bool> ExisteDocumentoAsync(string numeroDocumento);
        Task<bool> ExisteCorreoAsync(string correo);
    }
}