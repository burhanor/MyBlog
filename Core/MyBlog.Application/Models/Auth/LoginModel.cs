﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Auth
{
	public class LoginModel
	{
		public string NickNameOrEmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
	}
}
