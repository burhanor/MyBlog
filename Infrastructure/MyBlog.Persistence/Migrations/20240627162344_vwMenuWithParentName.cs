using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwMenuWithParentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW vwMenuWithParentName AS
								Select m1.Id,m1.ParentId,m1.Name,m1.Url,m1.IconContent,m1.DisplayOrder,ISNULL(m2.Name,'') AS ParentMenuName from Menus m1 left join Menus m2 on m1.ParentId=m2.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vwMenuWithParentName");
        }
    }
}
