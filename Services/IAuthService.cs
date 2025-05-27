using CobranzaPlus.Models;
using CobranzaPlus.Models.Dtos;

namespace CobranzaPlus.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto dto);
        Task<AuthResponseDto> Login(LoginDto dto);

        Task<List<AppUsuario>> ObtenerUsarios();
    }
}
