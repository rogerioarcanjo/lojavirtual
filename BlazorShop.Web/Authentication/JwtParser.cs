using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public static class JwtParser
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(jwt) as JwtSecurityToken;
        var claims = jsonToken?.Claims;
        return claims ?? Enumerable.Empty<Claim>();
    }

    public static string GetUserNameFromJwt(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(jwt) as JwtSecurityToken;
        var userNameClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
        return userNameClaim?.Value;
    }
}
