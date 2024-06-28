using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class SeriesImage:IEntityBase
	{
        public int SeriesId { get; set; }
        public int ImageId { get; set; }
        public Series Series { get; set; }
        public Image Image { get; set; }
    }
}
