using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Webapi.Domain.src.RepoInterfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Webapi.Business.src.Shared
{
    public class AuthServices : IAuthService
    {
        private readonly IUserRepo _userRepo;

        public AuthServices(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string> VerifyCredentials(UserCredentialsDto credentials)
        {
            var foundUserEmail = await _userRepo.FindByEmail(credentials.Email);
            var isAuthenticated = PasswordService.VerifyPassword(credentials.Password, foundUserEmail.Password, foundUserEmail.Salt);
            if (!isAuthenticated)
            {
                throw new Exception("Invalid credentials");
            }
            return GenerateToken(foundUserEmail);
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole.ToString() )
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("prackey-backend-jsdguyfsdgcjsdbchjsdb jdhscjysdcsdj"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "prac-backend",
                Expires = DateTime.Now.AddMinutes(10),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}