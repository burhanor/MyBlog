using MyBlog.Domain.Commons;

namespace MyBlog.Domain.Entities
{
	public class Slider:EntityBase
	{

		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
