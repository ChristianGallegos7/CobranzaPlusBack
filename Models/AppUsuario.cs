using Microsoft.AspNetCore.Identity;

namespace CobranzaPlus.Models
{
    public class AppUsuario : IdentityUser
    {
        public string? NombreCompleto { get; set; }
    }
}
