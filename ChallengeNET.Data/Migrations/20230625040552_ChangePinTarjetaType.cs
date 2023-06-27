using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeNET.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangePinTarjetaType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "pin_tarjeta",
                table: "Tarjetas",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "pin_tarjeta",
                table: "Tarjetas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);
        }
    }
}
