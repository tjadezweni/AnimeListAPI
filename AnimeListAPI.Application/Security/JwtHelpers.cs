using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Security;

public static class JwtHelpers
{
    public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid id)
    {
        var claims = new List<Claim>()
        {
            new Claim("Id", userAccounts.Id.ToString()),
            new Claim(ClaimTypes.Name, userAccounts.Username),
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString())
        };
        return claims;
    }

    public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid id)
    {
        id = Guid.NewGuid();
        return GetClaims(userAccounts, id);
    }

    public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
    {
        try
        {
            var userToken = new UserTokens();
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
            Guid id = Guid.Empty;
            DateTime expireTime = DateTime.UtcNow.AddDays(1);
            userToken.Validity = expireTime.TimeOfDay;
            var jwtToken = new JwtSecurityToken(
                issuer: jwtSettings.ValidIssuer,
                audience: jwtSettings.ValidAudience,
                claims: GetClaims(model, out id),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(expireTime).DateTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            userToken.Username = model.Username;
            userToken.Id = model.Id;
            userToken.GuidId = id;
            return userToken;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
