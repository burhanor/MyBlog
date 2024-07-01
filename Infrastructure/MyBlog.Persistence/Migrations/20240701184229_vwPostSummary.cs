using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwPostSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"CREATE VIEW vwPostSummary AS
                    SELECT        p.Id, p.Title, p.Summary, p.Url, p.PublishDate, p.IsPublished, dbo.GetPostImagePath(p.Id, 1) AS HeaderPath, dbo.GetPostImagePath(p.Id, 2) AS ThumbnailPath, ISNULL(i.Path, '') AS AuthorPath, ISNULL(a.Nickname, '') 
                    AS AuthorName
                    FROM            dbo.Posts AS p INNER JOIN
                    dbo.Authors AS a ON a.Id = p.AuthorId LEFT OUTER JOIN
                    dbo.Images AS i ON i.Id = a.ImageId ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP VIEW vwPostSummary");

		}
	}
}
