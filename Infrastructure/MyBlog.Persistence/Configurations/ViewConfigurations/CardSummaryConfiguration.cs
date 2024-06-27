using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Configurations.ViewConfigurations
{
	public class CardSummaryConfiguration : IEntityTypeConfiguration<CardSummary>
	{
		public void Configure(EntityTypeBuilder<CardSummary> builder)
		{
			builder.HasNoKey();
			builder.ToView("vwCardSummary");
		}
	}
}
