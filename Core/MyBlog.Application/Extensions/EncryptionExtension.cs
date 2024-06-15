using System.Security.Cryptography;
using System.Text;

namespace MyBlog.Application.Extensions
{
	public static class EncryptionExtension
	{
		public static string Encrypt(this string password) => Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));

		public static bool Verify(this string password, string hash) => password.Encrypt() == hash;
	}
}
