using MyBlog.Application.Enums;
using MyBlog.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions
{
	/// <summary>
	/// Hata bilgilerini tutmak için oluşturulan sınıf
	/// </summary>
	public class ExceptionModel
	{
		public string Message { get; set; } = string.Empty;
		public string Detail { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
		public List<string> ValidationErrors { get; set; } = [];
		public HttpStatus Status { get; set; }
		public override string ToString() => JsonConvert.SerializeObject(this);

		

		
	}
}
