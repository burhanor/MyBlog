using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwCardSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW vwCardSummary AS
                Select c.Id,c.Title,c.Content,c.DisplayOrder,c.Url,ISNULL(i.Path,'') as ImagePath from Cards c left join Images i on c.ImageId=i.Id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vwCardSummary");
        }
    }
}
