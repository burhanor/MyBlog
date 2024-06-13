using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Configurations.EntityConfigurations
{
	internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
	{
		public void Configure(EntityTypeBuilder<Slider> builder)
		{
		}
	}
}
