using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HighwayTransportation.Core.Dtos;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using HighwayTransportation.Domain;

namespace HighwayTransportation.Providers
{
    public class AppUserProvider
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AppUserProvider(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var user = _context.AppUsers.FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
            if (user == null)
            {
                return null;
            }

            var token = GenerateJwtToken(user);

            return token;
        }

        private string GenerateJwtToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()), 
                }),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JwtSettings:ExpirationHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JwtSettings:Audience"],
                Issuer = _configuration["JwtSettings:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public async Task<string> SignUp(SignUpRequest signUpRequest)
        {
            // Kullanıcı adının benzersiz olduğunu kontrol edin
            var existingUser = _context.AppUsers.FirstOrDefault(u => u.Email == signUpRequest.Email);
            if (existingUser != null)
            {
                return null; 
            }

            var newUser = new AppUser
            {
                Name = signUpRequest.Name,
                Surname = signUpRequest.Surname,
                Email = signUpRequest.Email,
                PhoneNumber = signUpRequest.PhoneNumber,
                Password = signUpRequest.Password,
                // Diğer kullanıcı bilgilerini buradan alabilirsiniz
            };

            _context.AppUsers.Add(newUser);
            await _context.SaveChangesAsync();

            return "User created successfully"; 
        }
    }
}
