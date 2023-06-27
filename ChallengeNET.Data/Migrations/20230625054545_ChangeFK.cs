using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeNET.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_tarjeta_id",
                table: "Balances");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_tarjeta_id",
                table: "Balances",
                column: "tarjeta_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_tarjeta_id",
                table: "Balances");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_tarjeta_id",
                table: "Balances",
                column: "tarjeta_id");
        }
    }
}
