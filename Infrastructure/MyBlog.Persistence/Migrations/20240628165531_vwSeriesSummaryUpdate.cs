using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwSeriesSummaryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW [dbo].[vwSeriesSummary] AS
	            Select s.Id,s.Title,s.Summary,s.Url,s.PublishedDate,s.IsPublished,[dbo].[GetSeriesImagePath] (Id,3) as HeaderPath,[dbo].[GetSeriesImagePath] (Id,4) as ThumbnailPath from Series s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW [dbo].[vwSeriesSummary] AS
				Select Id from Series");
        }
    }
}
