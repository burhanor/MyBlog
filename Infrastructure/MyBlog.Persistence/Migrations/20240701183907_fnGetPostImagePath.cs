using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fnGetPostImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[GetPostImagePath]
                (
                	@postId int,
                	@imageType int
                )
                RETURNS nvarchar(max)
                AS
                BEGIN
                	DECLARE @result nvarchar(max)
                	SET @result=ISNULL((SELECT i.Path FROM Posts p inner join PostImages pi on p.Id=pi.PostId inner join Images i on pi.ImageId=i.Id where i.ImageType = @imageType  and p.Id=@postId),'')
                	RETURN @result
                END
            ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FUNCTION [dbo].[GetPostImagePath]");

		}
	}
}
