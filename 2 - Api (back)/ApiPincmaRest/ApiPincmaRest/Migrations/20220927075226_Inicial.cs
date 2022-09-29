using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPincmaRest.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoXBilletera",
                table: "CryptoXBilletera");

            migrationBuilder.RenameTable(
                name: "CryptoXBilletera",
                newName: "cryptoXBilletera");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cryptoXBilletera",
                table: "cryptoXBilletera",
                columns: new[] { "idCrypto", "idBilletera" });

            migrationBuilder.CreateTable(
                name: "Billetera",
                columns: table => new
                {
                    idBilletera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billetera", x => x.idBilletera);
                });

            migrationBuilder.CreateTable(
                name: "Crypto",
                columns: table => new
                {
                    idCrypto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCrypto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: false),
                    nombreCorto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crypto", x => x.idCrypto);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    idCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cuentaValidada = table.Column<bool>(type: "bit", nullable: false),
                    hashRecuperacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.idCuenta);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    idDomicilio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLocalidad = table.Column<int>(type: "int", nullable: false),
                    calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    altura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.idDomicilio);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    idLocalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProvincia = table.Column<int>(type: "int", nullable: false),
                    nombreLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.idLocalidad);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    idLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.idLog);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    idOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaOperacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idTipoOperacion = table.Column<int>(type: "int", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: false),
                    idCuentaOrigen = table.Column<int>(type: "int", nullable: false),
                    idCuentaDestino = table.Column<int>(type: "int", nullable: false),
                    idCrypto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    operacionFinalizada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.idOperacion);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    idPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.idPais);
                });

            migrationBuilder.CreateTable(
                name: "PrecioCompra",
                columns: table => new
                {
                    idPrecioCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCrypto = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioCompra", x => x.idPrecioCompra);
                });

            migrationBuilder.CreateTable(
                name: "PrecioVenta",
                columns: table => new
                {
                    idPrecioVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCrypto = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioVenta", x => x.idPrecioVenta);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    idProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPais = table.Column<int>(type: "int", nullable: false),
                    nombreProvincia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.idProvincia);
                });

            migrationBuilder.CreateTable(
                name: "RegistroIngresos",
                columns: table => new
                {
                    idIngreso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroIngresos", x => x.idIngreso);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    idTipoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.idTipoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "TipoOperacion",
                columns: table => new
                {
                    idTipoOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTipoOperacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOperacion", x => x.idTipoOperacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idTipoDocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.mail);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billetera");

            migrationBuilder.DropTable(
                name: "Crypto");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Domicilio");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "PrecioCompra");

            migrationBuilder.DropTable(
                name: "PrecioVenta");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "RegistroIngresos");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "TipoOperacion");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cryptoXBilletera",
                table: "cryptoXBilletera");

            migrationBuilder.RenameTable(
                name: "cryptoXBilletera",
                newName: "CryptoXBilletera");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoXBilletera",
                table: "CryptoXBilletera",
                columns: new[] { "idCrypto", "idBilletera" });
        }
    }
}
