using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeNET.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNroTarjeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nro_tarjeta",
                table: "Tarjetas",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "nro_tarjeta",
                table: "Tarjetas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);
        }
    }
}
