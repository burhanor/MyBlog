using MyBlog.Application.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Queries.GetTag
{
	public class GetTagQueryResponse:TagModel
	{
        public int Id { get; set; }
    }
}
