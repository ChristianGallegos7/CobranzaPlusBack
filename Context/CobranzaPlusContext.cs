using CobranzaPlus.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CobranzaPlus.Context
{
    public class CobranzaPlusContext : IdentityDbContext<AppUsuario>
    {
        public CobranzaPlusContext(DbContextOptions<CobranzaPlusContext> options) : base(options)
        {

        }

    }
}
