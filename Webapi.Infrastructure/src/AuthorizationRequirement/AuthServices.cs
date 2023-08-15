using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Domain.src.RepoInterfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Webapi.Business.src.Abstractions;
using Webapi.Business.src.Shared;

namespace Webapi.Infrastructure.src.AuthorizationRequirement
{
    public class AuthServices : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _configuration;

        public AuthServices(IUserRepo userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<string> VerifyCredentials(UserCredentialsDto credentials)
        {
            var foundUserEmail = await _userRepo.FindByEmail(credentials.Email) ?? throw new Exception("Email not found");
            var isAuthenticated = PasswordService.VerifyPassword(credentials.Password, foundUserEmail.Password, foundUserEmail.Salt);
            if (!isAuthenticated)
            {
                throw new Exception("Invalid Password");
            }
            return GenerateToken(foundUserEmail);
        }

        private string GenerateToken(User user)  // this logic needs to go infra layer!!! And Hide the key
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole.ToString() )
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("TokenSettings:SecurityKey")));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration.GetValue<string>("TokenSettings:Issuer"),
                Expires = DateTime.Now.AddMinutes(_configuration.GetValue<int>("TokenSettings:ExpirationMinutes")),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}