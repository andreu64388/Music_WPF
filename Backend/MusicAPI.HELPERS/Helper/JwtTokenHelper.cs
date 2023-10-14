using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicAPI.HELPRES.Helper;

public static class JwtTokenHelper
{
	private const string SecretKey = "your_secret_key_here_with_at_least_32_bytes";

	private static readonly SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

	public static string GenerateToken(int userId)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var claims = new ClaimsIdentity(new[] { new Claim("userId", userId.ToString()) });

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = claims,
			Expires = DateTime.UtcNow.AddDays(365),
			SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}

	public static int ValidateTokenAndGetUserId(string token)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		try
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = SecurityKey,
				ValidateIssuer = false,
				ValidateAudience = false,
				ClockSkew = TimeSpan.Zero
			};

			var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
			var userIdClaim = claimsPrincipal.FindFirst("userId");

			if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
			{
				return userId;
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}

		return -1;
	}
}