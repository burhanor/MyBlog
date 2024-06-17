using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBlog.Application.Consts;
using MyBlog.Application.Interfaces.Tokens;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Tokens
{
	//TODO: Token ve Claim bilgilerini kaydetme işlemi yapılacak.
	public class TokenService(IOptions<TokenModel> options, IUow uow) : ITokenService
	{
		private readonly TokenModel options=options.Value;
		private readonly IUow uow = uow;
	
		public async Task<JwtSecurityToken> GenerateAccessToken(Author author, IList<string>? roles)
		{
			List<Claim> claims = [
				new (ClaimTypes.NameIdentifier,author.Id.ToString()),
				new (ClaimTypes.Name,author.Nickname ?? string.Empty),
				new (JwtRegisteredClaimNames.Email,author.EmailAddress ?? string.Empty)
				];
			if (roles?.Count>0)
				claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
			SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(options.SecretKey));
			JwtSecurityToken token = new(
				issuer: options.Issuer,
				audience: options.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(options.TokenValidtyInMinutes),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
				);

			return token;
		}

		public string GenerateRefreshToken()
		{
			byte[] randomNumber = new byte[32];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}

		public ClaimsPrincipal? GetClaimsPrincipalFromToken(string token)
		{
			TokenValidationParameters tokenValidationParameters = new()
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
				ValidateIssuer = false,
				ValidIssuer = options.Issuer,
				ValidateAudience = false,
				ValidAudience = options.Audience,
				ValidateLifetime = false
			};
			JwtSecurityTokenHandler tokenHandler = new();
			ClaimsPrincipal? principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
			if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,StringComparison.InvariantCultureIgnoreCase))
				throw new SecurityTokenException(Const.Token.INVALID_TOKEN);
			return principal;
		}
	}
}
