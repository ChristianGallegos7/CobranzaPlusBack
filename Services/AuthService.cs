using CobranzaPlus.Models;
using CobranzaPlus.Models.Dtos;
using CobranzaPlus.Repositories;
using CobranzaPlus.Token;
using Microsoft.AspNetCore.Identity;

namespace CobranzaPlus.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _repo;
        private readonly UserManager<AppUsuario> _userManager;
        private readonly SignInManager<AppUsuario> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IJwtGenerator _jwt;
        public AuthService(SignInManager<AppUsuario> signInManager, IConfiguration configuration, UserManager<AppUsuario> userManager, IJwtGenerator jwt, IUserRepository repo)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
            _jwt = jwt;
            _repo = repo;
        }

        public async Task<AuthResponseDto> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email!);

            if (user == null)
            {
                throw new Exception("Credencailes invalidas");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password!, false);

            if (!result.Succeeded)
            {
                throw new Exception("Credenciales invalidas");
            }


            return await _jwt.CrearToken(user);

        }

        public async Task<List<AppUsuario>> ObtenerUsarios()
        {
            try
            {
                var result = await _repo.ObtenerUsuarios();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AuthResponseDto> Register(RegisterDto dto)
        {
            var user = new AppUsuario
            {
                NombreCompleto = dto.NombreCompleto,
                Email = dto.Email,
                UserName = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password!);

            if (!result.Succeeded)
            {
                throw new Exception("Error al registrar usuario");
            }

            return await _jwt.CrearToken(user);

        }
    }
}
