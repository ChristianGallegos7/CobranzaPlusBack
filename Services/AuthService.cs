using CobranzaPlus.Models;
using CobranzaPlus.Models.Dtos;
using CobranzaPlus.Token;
using Microsoft.AspNetCore.Identity;

namespace CobranzaPlus.Services
{
    public class AuthService : IAuthService
    {


        private readonly UserManager<AppUsuario> _userManager;
        private readonly SignInManager<AppUsuario> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IJwtGenerator _jwt;
        public AuthService(SignInManager<AppUsuario> signInManager, IConfiguration configuration, UserManager<AppUsuario> userManager, IJwtGenerator jwt)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
            _jwt = jwt;
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
