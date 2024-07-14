using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlog.Application.Extensions
{
	public static class HttpRequestExtension
	{
		public static string Serialize(this HttpRequest request)
		{
			string result = string.Empty;
			var requestInfo = new
			{
				// Temel HttpRequest bilgileri
				Method = request.Method,
				Scheme = request.Scheme,
				Host = request.Host.ToString(),
				Path = request.Path.ToString(),
				QueryString = request.QueryString.ToString(),
				// Header'lar
				Headers = request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
				// Body (eğer uygulanabilirse)
				Body = ReadRequestBody(request)
			};
			return JsonSerializer.Serialize(requestInfo);

		}

		private static string ReadRequestBody(HttpRequest request)
		{
			Task.Run(async () =>
		  {
			  request.EnableBuffering();

			  var body = string.Empty;
			  using (var reader = new StreamReader(request.Body, leaveOpen: true))
			  {
				  body = await reader.ReadToEndAsync();
				  request.Body.Position = 0; // Stream'in başına geri dön
			  }

			  return body;
		  });
			return string.Empty;

		}
	}
}
