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
	internal class AuthorSummaryConfiguration : IEntityTypeConfiguration<AuthorSummary>
	{
		public void Configure(EntityTypeBuilder<AuthorSummary> builder)
		{
			builder.HasNoKey();
			builder.ToView("vwAuthorSummary");
		}
	}
}
