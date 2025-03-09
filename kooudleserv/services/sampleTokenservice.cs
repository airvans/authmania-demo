
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public class Tokens{

     public static Task<string> GenerateidTokenAsync(string clientId, string issuer,string nonce)
    {
        var claims = new []{

            new Claim(JwtRegisteredClaimNames.Sub,"demo-user123"),
            new Claim(JwtRegisteredClaimNames.Aud, clientId),// The audience (client)
            new Claim(JwtRegisteredClaimNames.Iss, issuer),//The token issuer
            new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddMinutes(60).ToUnixTimeSeconds().ToString()),// Expiration time
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),// Issued-at time
            new Claim(JwtRegisteredClaimNames.Nonce,nonce)
        };

        var key = new SymmetricSecurityKey(Convert.FromBase64String("yIZym5aDTZ2w1I7b9UBOMjJCj6Bp2VxcqLWRpnIVI0SeIm6oPo1Ts3BKaZ3EFCG7"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
        issuer,
        clientId,
        claims,
        expires: DateTime.UtcNow.AddMinutes(30),
        signingCredentials: creds);

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        
    }


}