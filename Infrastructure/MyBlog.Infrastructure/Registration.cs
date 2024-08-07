﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyBlog.Application.Interfaces.Tokens;
using MyBlog.Infrastructure.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure
{
	public static class Registration
	{
		public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
		{
			services.Configure<TokenModel>(configuration.GetSection("JWT"));
			services.AddTransient<ITokenService, TokenService>();
			
			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
			{
				//TODO: Ayarlar yapılacak
				opt.SaveToken = true;
				opt.TokenValidationParameters = new()
				{
					ValidateIssuerSigningKey = true,

					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = false,
					ValidIssuer = configuration["JWT:Issuer"],
					ValidAudience = configuration["JWT:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
					ClockSkew = TimeSpan.Zero
				};
			});


		}
	}
}
