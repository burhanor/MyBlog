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
	public class PostSeriesSummaryConfiguration : IEntityTypeConfiguration<PostSeriesSummary>
	{
		public void Configure(EntityTypeBuilder<PostSeriesSummary> builder)
		{
			builder.HasNoKey();
			builder.ToView("vwPostSeriesSummary");
		}
	}
}
