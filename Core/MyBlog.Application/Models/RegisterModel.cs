using MyBlog.Application.Features.Auth.Command.Register;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models
{
	public class RegisterModel
	{
		[Required]
		public string Nickname { get; set; } = string.Empty;

		[Required]
		public string EmailAddress { get; set; } = string.Empty;

		[Required]
		public string Password { get; set; } = string.Empty;


	}
}
