using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Configurations.ViewConfigurations
{
	internal class SliderSummaryConfiguration : IEntityTypeConfiguration<SliderSummary>
	{
		public void Configure(EntityTypeBuilder<SliderSummary> builder)
		{
			builder.HasNoKey();
			builder.ToView("vwSliderSummary");
		}
	}
}
