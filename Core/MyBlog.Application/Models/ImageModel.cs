using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models
{
	public class ImageModel
	{
        public IFormFile Image { get; set; }
    }
}
