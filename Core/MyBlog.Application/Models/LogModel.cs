using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models
{
	public class LogModel
	{
        public LogModel()
        {
            
        }
        public LogModel(int statusCode,string? methodType, string? path, int userId, string ipAddress,string nickname, string response)
		{
			StatusCode = statusCode;
			MethodType = methodType??string.Empty;
			Path = path ?? string.Empty;
			UserId = userId;
			IpAddress = ipAddress;
			Response = response;
			Nickname = nickname;
		}
        public int StatusCode { get; set; }
        public DateTime DateTime { get; set; }=DateTime.Now;
        public string MethodType { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string IpAddress { get; set; } = string.Empty;
		public string Response { get; set; } = string.Empty;
		public string Nickname { get; set; } = string.Empty;

        public override string ToString()
		{
			StringBuilder logBuilder= new StringBuilder();
			logBuilder.AppendLine($"{"Time",-15} = {DateTime}");
			logBuilder.AppendLine($"{"Status Code",-15} = {StatusCode}");
			logBuilder.AppendLine($"{"Type",-15} = {MethodType}");
			logBuilder.AppendLine($"{"Path",-15} = {Path}");
			logBuilder.AppendLine($"{"IpAddress",-15} = {IpAddress}");
			logBuilder.AppendLine($"{"UserId",-15} = {UserId}");
			logBuilder.AppendLine($"{"Nickname",-15} = {Nickname}");
			logBuilder.AppendLine($"{"Response",-15} = {Response}");
			logBuilder.AppendLine(" ============================================================");
			logBuilder.AppendLine("\n\n");
			return logBuilder.ToString();
		}
	}
}
