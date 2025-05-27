using CobranzaPlus.Models;

namespace CobranzaPlus.Repositories
{
    public interface IUserRepository
    {
        Task<List<AppUsuario>> ObtenerUsuarios();
    }
}
