using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeNET.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    tarjeta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nro_tarjeta = table.Column<int>(type: "int", nullable: false),
                    pin_tarjeta = table.Column<int>(type: "int", nullable: false),
                    tarjeta_bloqueada = table.Column<bool>(type: "bit", nullable: false),
                    vencimiento_tarjeta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.tarjeta_id);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    balance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarjeta_id = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.balance_id);
                    table.ForeignKey(
                        name: "FK_Balances_Tarjetas_tarjeta_id",
                        column: x => x.tarjeta_id,
                        principalTable: "Tarjetas",
                        principalColumn: "tarjeta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    operacion_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarjeta_id = table.Column<int>(type: "int", nullable: false),
                    cod_operacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fecha_operacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.operacion_id);
                    table.ForeignKey(
                        name: "FK_Operaciones_Tarjetas_tarjeta_id",
                        column: x => x.tarjeta_id,
                        principalTable: "Tarjetas",
                        principalColumn: "tarjeta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retiros",
                columns: table => new
                {
                    retiro_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarjeta_id = table.Column<int>(type: "int", nullable: false),
                    operacion_id = table.Column<int>(type: "int", nullable: false),
                    fecha_retiro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    monto_retiro = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retiros", x => x.retiro_id);
                    table.ForeignKey(
                        name: "FK_Retiros_Operaciones_operacion_id",
                        column: x => x.operacion_id,
                        principalTable: "Operaciones",
                        principalColumn: "operacion_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retiros_Tarjetas_tarjeta_id",
                        column: x => x.tarjeta_id,
                        principalTable: "Tarjetas",
                        principalColumn: "tarjeta_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_tarjeta_id",
                table: "Balances",
                column: "tarjeta_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_tarjeta_id",
                table: "Operaciones",
                column: "tarjeta_id");

            migrationBuilder.CreateIndex(
                name: "IX_Retiros_operacion_id",
                table: "Retiros",
                column: "operacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Retiros_tarjeta_id",
                table: "Retiros",
                column: "tarjeta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Retiros");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Tarjetas");
        }
    }
}
