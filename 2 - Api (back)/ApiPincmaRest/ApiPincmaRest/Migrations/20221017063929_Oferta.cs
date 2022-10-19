using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPincmaRest.Migrations
{
    public partial class Oferta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaCreacion",
                table: "Usuario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    idOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBilletera = table.Column<int>(type: "int", nullable: false),
                    idCrypto = table.Column<int>(type: "int", nullable: false),
                    nombreCrypto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precioU = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    precioP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.idOferta);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaCreacion",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
