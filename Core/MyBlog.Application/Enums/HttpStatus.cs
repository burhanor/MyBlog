using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Enums
{
	public enum HttpStatus
	{
		Ok = 200,
		Created = 201,
		NoContent = 204,
		BadRequest = 400,
		Unauthorized = 401,
		UnprocessableEntity = 422,
		Forbidden = 403,
		NotFound = 404,
		InternalServerError = 500
	}
}
