using Microsoft.EntityFrameworkCore.Migrations;
using PostgresEnumError.Models;

#nullable disable

namespace PostgresEnumError.Migrations
{
    /// <inheritdoc />
    public partial class AddEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // This migration will only work when adding this hack:
            // migrationBuilder.Sql("DROP TYPE IF EXISTS marriage_status;");
            
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:marriage_status", "divorced,married,single");

            migrationBuilder.AddColumn<MarriageStatus>(
                name: "MarriageStatus",
                table: "People",
                type: "marriage_status",
                nullable: false,
                defaultValue: MarriageStatus.Single);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarriageStatus",
                table: "People");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:marriage_status", "divorced,married,single");
        }
    }
}
