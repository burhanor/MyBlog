using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vwCategoryWithParentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"CREATE VIEW vwCategoryWithParentName AS
								Select c.Id,c.Name,c.ParentId,c.DisplayOrder,c.Url,c.IconContent,IsNULL(c2.Name,'') as ParentCategoryName from Categories c left join Categories c2 on c.Id=c2.ParentId");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP VIEW vwCategoryWithParentName");
		}
    }
}
