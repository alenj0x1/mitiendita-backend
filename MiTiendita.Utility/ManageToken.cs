using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiTiendita.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.Utility
{
  public class ManageToken
  {
    public string CreateToken(IConfiguration config, User model)
    {
      var key = config.GetSection("JWTSettings:key").Value;
      var keyBytes = Encoding.ASCII.GetBytes(key);

      var credentialsToken = new SigningCredentials(
        new SymmetricSecurityKey(keyBytes),
        SecurityAlgorithms.HmacSha256
      );

      var claims = new ClaimsIdentity();

      claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(model.UserId)));
      claims.AddClaim(new Claim(ClaimTypes.Role, Convert.ToString(model.UserRole)));

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = claims,
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = credentialsToken
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
      
      return tokenHandler.WriteToken(tokenConfig);
    }
  }
}
