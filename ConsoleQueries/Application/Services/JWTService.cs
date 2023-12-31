using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleQueries.Application.Services;

public class JwtService:IJWTService
{
    private readonly DataBaseContext _dbc;
    private readonly IConfiguration _configuration;
    public JwtService(DataBaseContext dbc,IConfiguration configuration)
    {
        _dbc = dbc;
        _configuration = configuration;
    }
    public async Task<string> Authenticate(UserFormDto userForm)
    {
        if(!_dbc.Users.Any(x=>x.Email==userForm.Email&&x.Password==userForm.Password))
        {
            return String.Empty;
        }
        var user = await _dbc.Users.Where(x => x.Email == userForm.Email && x.Password == userForm.Password).FirstOrDefaultAsync();
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:KEY"]!);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,user?.Email ?? throw new InvalidOperationException()),
                new Claim(ClaimTypes.Role,user.type.ToString())
            }),
            Audience = _configuration["JWT:Audience"],
            Issuer = _configuration["JWT:Issuer"],
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    private string GetStringSha256Hash(string text)
    {
        if (String.IsNullOrEmpty(text))
            return String.Empty;

        using (var sha = new System.Security.Cryptography.SHA256Managed())
        {
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hash = sha.ComputeHash(textData);
            return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
    }
}