using MyBlog.Domain.Commons;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class Image:EntityBase
	{
		public string OriginalName { get; set; } = string.Empty;
		public string UniqueName { get; set; } = string.Empty;
		public string Extension { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public byte[] BinaryFile { get; set; }
        public ImageType ImageType { get; set; }

        public Slider Slider { get; set; }

        public Card Card { get; set; }

        public Author Author { get; set; }
		public ICollection<PostImage> PostImages { get; set; }
		public ICollection<SeriesImage> SeriesImages { get; set; }
    }
}
