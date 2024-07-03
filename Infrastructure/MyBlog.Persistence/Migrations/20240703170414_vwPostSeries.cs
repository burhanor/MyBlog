using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwPostSeries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"CREATE VIEW vwPostSeriesSummary AS
                   Select ps.PostId,ps.SeriesId,ps.DisplayOrder,vps.Title,vps.Summary,vps.Url,vps.ThumbnailPath,vps.AuthorName,vps.AuthorPath from PostSeries ps inner join vwPostSummary vps on ps.PostId=vps.Id ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

			migrationBuilder.Sql("DROP VIEW vwPostSeriesSummary");
		}
    }
}
