using CarLocadora.Modelo.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Login
{
    public class GeradorToken
    {
        private readonly string _secreto;

        public GeradorToken()
        {
            _secreto = Environment.GetEnvironmentVariable("JWT_SECRETO");
        }
        public LoginRespostaModel GerarToken(LoginRespostaModel loginRespostaModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Convert.FromBase64String(_secreto);

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loginRespostaModel.Usuario)
            });
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = "EmitenteDoJWT",
                Audience = "DestinatarioDoJWT",
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = signingCredentials,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            loginRespostaModel.Autenticado = true;
            loginRespostaModel.DataExpiracao = tokenDescriptor.Expires;
            loginRespostaModel.Token = tokenHandler.WriteToken(token);

            return loginRespostaModel;
        }
    }
}
