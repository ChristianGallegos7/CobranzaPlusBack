using CobranzaPlus.Context;
using CobranzaPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace CobranzaPlus.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CobranzaPlusContext _context;
        public UserRepository(CobranzaPlusContext context)
        {
            _context = context;
        }
        public async Task<List<AppUsuario>> ObtenerUsuarios()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
