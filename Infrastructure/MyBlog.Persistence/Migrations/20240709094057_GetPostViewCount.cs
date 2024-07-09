using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GetPostViewCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[GetPostViewCount]
                (
                	@postId int
                )
                RETURNS int
                AS
                BEGIN
                	DECLARE @result int
                	SET @result=ISNULL((SELECT COUNT(*) FROM PostViews WHERE PostId=@postId),0)
                	RETURN @result
                END
            ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FUNCTION [dbo].[GetPostViewCount]");

		}
	}
}
