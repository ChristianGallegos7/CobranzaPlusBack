using CobranzaPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CobranzaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        
        public AuthController(UserManager<AppUsuario> userManager )
        {
            
        }
    }
}
