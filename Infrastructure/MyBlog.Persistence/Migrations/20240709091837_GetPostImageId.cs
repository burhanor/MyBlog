using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GetPostImageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[GetPostImageId]
                (
                	@postId int,
                	@imageType int
                )
                RETURNS int
                AS
                BEGIN
                	DECLARE @result int
                	SET @result=ISNULL((SELECT i.Id FROM Posts p inner join PostImages pi on p.Id=pi.PostId inner join Images i on pi.ImageId=i.Id where i.ImageType = @imageType  and p.Id=@postId),0)
                	RETURN @result
                END
            ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FUNCTION [dbo].[GetPostImageId]");

		}
	}
}
