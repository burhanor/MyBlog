using MyBlog.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyBlog.Application.Interfaces.Tokens
{
	public interface ITokenService
	{
		Task<JwtSecurityToken> GenerateAccessToken(Author author, IList<string>? roles);
		string GenerateRefreshToken();
		ClaimsPrincipal? GetClaimsPrincipalFromToken(string token);
	}
}
