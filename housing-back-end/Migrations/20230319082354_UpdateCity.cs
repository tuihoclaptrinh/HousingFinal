using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace housing_back_end.Migrations
{
    public partial class UpdateCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE [dbo].[Cities] SET [Country]='USA' WHERE [Country] IS NULL");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
