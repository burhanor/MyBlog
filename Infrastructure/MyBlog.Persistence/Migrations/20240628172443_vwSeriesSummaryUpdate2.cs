using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwSeriesSummaryUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"ALTER VIEW [dbo].[vwSeriesSummary] AS
                SELECT        s.Id, s.Title, s.Summary, s.Url, s.PublishedDate, s.IsPublished, dbo.GetSeriesImagePath(s.Id, 3) AS HeaderPath, dbo.GetSeriesImagePath(s.Id, 4) AS ThumbnailPath, ISNULL(i.Path, '') AS AuthorPath, ISNULL(a.Nickname, '')
                AS AuthorName
                FROM            dbo.Series AS s 
                INNER JOIN dbo.Authors AS a ON a.Id = s.AuthorId 
                LEFT JOIN dbo.Images i on i.Id=a.ImageId");

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW [dbo].[vwSeriesSummary] AS
	            Select s.Id,s.Title,s.Summary,s.Url,s.PublishedDate,s.IsPublished,[dbo].[GetSeriesImagePath] (Id,3) as HeaderPath,[dbo].[GetSeriesImagePath] (Id,4) as ThumbnailPath from Series s");
        }
    }
}
