using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwSliderSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW vwSliderSummary AS
            Select s.Id,s.Title,s.Content,s.Url,s.DisplayOrder,ISNULL(i.Path,'') as ImagePath from Sliders s  left join Images i on s.ImageId=i.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vwSliderSummary");
        }
    }
}
