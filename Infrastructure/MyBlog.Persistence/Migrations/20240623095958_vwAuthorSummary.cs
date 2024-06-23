using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwAuthorSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW vwAuthorSummary AS
								Select a.Id,a.Nickname,a.EmailAddress,a.Summary,a.AuthorType,i.Path from Authors a left join Images i on a.ImageId=i.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vwAuthorSummary");
        }
    }
}
