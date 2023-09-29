using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asiento_Contable.Migrations
{
    /// <inheritdoc />
    public partial class Juanpi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivosFijos",
                columns: table => new
                {
                    IdAsiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaAsiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentaContable = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    MontoMovimiento = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivosFijos", x => x.IdAsiento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivosFijos");
        }
    }
}
