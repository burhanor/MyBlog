using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Application.Models.Post;
using MyBlog.Domain.Views;
using MyBlog.Persistence.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Configurations.ViewConfigurations
{
	internal class PostSummaryConfiguration:IEntityTypeConfiguration<PostSummary>
	{
		public void Configure(EntityTypeBuilder<PostSummary> builder)
		{
			builder.HasNoKey();
			builder.ToView("vwPostSummary");
		}
	}
}
