using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GetSeriesImageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[GetSeriesImageId]
                (
                	@seriesId int,
                	@imageType int
                )
                RETURNS int
                AS
                BEGIN
                	DECLARE @result int
                	SET @result=ISNULL((SELECT i.Id FROM Series s inner join SeriesImages si on s.Id=si.SeriesId inner join Images i on si.ImageId=i.Id where i.ImageType = @imageType  and s.Id=@seriesId),0)
                	RETURN @result
                END
            ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FUNCTION [dbo].[GetSeriesImageId]");

		}
	}
}
