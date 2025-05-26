using CobranzaPlus.Models;
using CobranzaPlus.Models.Dtos;

namespace CobranzaPlus.Token
{
    public interface IJwtGenerator
    {
        Task<AuthResponseDto> CrearToken(AppUsuario usuario);
    }
}
