using CobranzaPlus.Models;
using CobranzaPlus.Models.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CobranzaPlus.Token
{
    public class JwtGenerator : IJwtGenerator
    {

        private readonly IConfiguration _config;

        public JwtGenerator(IConfiguration config)
        {
            _config = config;
        }

        public Task<AuthResponseDto> CrearToken(AppUsuario usuario)
        {
            //Definir claims

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                new Claim(ClaimTypes.Email, usuario.Email!),
                new Claim(ClaimTypes.Name, usuario.NombreCompleto!)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
                );

            var response = new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email= usuario.Email,
                NombreCompleto = usuario.NombreCompleto

            };

            return Task.FromResult(response);
        }
    }
}
