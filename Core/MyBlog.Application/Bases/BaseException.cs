using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Bases
{
	// Proje için oluşturulacak özel hatalar bu sınıftan türeyecek
	public class BaseException:ApplicationException
	{
		public BaseException() { }
        public BaseException(string message):base(message) { }
    }
}
