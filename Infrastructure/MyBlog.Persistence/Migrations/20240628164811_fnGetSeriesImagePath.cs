using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fnGetSeriesImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[GetSeriesImagePath]
                (
                	@seriesId int,
                	@imageType int
                )
                RETURNS nvarchar(max)
                AS
                BEGIN
                	DECLARE @result nvarchar(max)
                	SET @result=ISNULL((SELECT i.Path FROM Series s inner join SeriesImages si on s.Id=si.SeriesId inner join Images i on si.ImageId=i.Id where i.ImageType = @imageType  and s.Id=@seriesId),'')
                	RETURN @result
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[GetSeriesImagePath]");
        }
    }
}
