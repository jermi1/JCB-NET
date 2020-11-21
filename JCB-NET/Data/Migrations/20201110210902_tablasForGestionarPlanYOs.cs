using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JCB_NET.Data.Migrations
{
    public partial class tablasForGestionarPlanYOs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.CreateTable(
                name: "T_Bodega",
                columns: table => new
                {
                    Id_Bodega = table.Column<short>(type: "smallint", nullable: false),
                    NombreBodega = table.Column<string>(type: "varchar(20)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Bodega", x => x.Id_Bodega);
                });

            migrationBuilder.CreateTable(
                name: "T_Estado_OS",
                columns: table => new
                {
                    Id_EstadoOS = table.Column<byte>(type: "tinyint", nullable: false),
                    NombreEstado = table.Column<string>(type: "varchar(22)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Estado_OS", x => x.Id_EstadoOS);
                });

            migrationBuilder.CreateTable(
                name: "T_Estado_Plan",
                columns: table => new
                {
                    Id_EstadoPlan = table.Column<byte>(type: "tinyint", nullable: false),
                    NombreEstado = table.Column<string>(type: "varchar(22)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Estado_Plan", x => x.Id_EstadoPlan);
                });

            migrationBuilder.CreateTable(
                name: "T_Maquina",
                columns: table => new
                {
                    Id_Maquina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(18)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: true),
                    Ubicacion = table.Column<string>(type: "varchar(30)", nullable: true),
                    Tamano = table.Column<string>(type: "varchar(40)", nullable: true),
                    Peso = table.Column<string>(type: "varchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Maquina", x => x.Id_Maquina);
                });

            migrationBuilder.CreateTable(
                name: "T_Periodicidad",
                columns: table => new
                {
                    Id_Periodicidad = table.Column<byte>(type: "tinyint", nullable: false),
                    Valor = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Periodicidad", x => x.Id_Periodicidad);
                });

            migrationBuilder.CreateTable(
                name: "T_Tecnico",
                columns: table => new
                {
                    Id_Tecnico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(18)", nullable: false),
                    ApePaterno = table.Column<string>(type: "varchar(25)", nullable: false),
                    ApeMaterno = table.Column<string>(type: "varchar(25)", nullable: true),
                    Direccion = table.Column<string>(type: "varchar(25)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(15)", nullable: false),
                    NroDocumento = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Tecnico", x => x.Id_Tecnico);
                });

            migrationBuilder.CreateTable(
                name: "T_Suministro",
                columns: table => new
                {
                    Id_Suministro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Bodega = table.Column<short>(type: "smallint", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: false),
                    StockMinimo = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Unidades = table.Column<string>(type: "varchar(15)", nullable: true),
                    Proveedor = table.Column<string>(type: "varchar(30)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Suministro", x => x.Id_Suministro);
                    table.ForeignKey(
                        name: "FK_T_Suministro_T_Bodega_Id_Bodega",
                        column: x => x.Id_Bodega,
                        principalTable: "T_Bodega",
                        principalColumn: "Id_Bodega",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Orden_Servicio",
                columns: table => new
                {
                    Id_Orden_Servicio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    CodigoOS = table.Column<string>(type: "varchar(15)", nullable: false),
                    TipoMantenimiento = table.Column<string>(type: "varchar(15)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaAtencion = table.Column<DateTime>(nullable: false),
                    ResultadoAtencion = table.Column<string>(type: "varchar(20)", nullable: true),
                    Id_EstadoOS = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Orden_Servicio", x => x.Id_Orden_Servicio);
                    table.ForeignKey(
                        name: "FK_T_Orden_Servicio_T_Estado_OS_Id_EstadoOS",
                        column: x => x.Id_EstadoOS,
                        principalTable: "T_Estado_OS",
                        principalColumn: "Id_EstadoOS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Orden_Servicio_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Plan_Mantenimiento_Preventivo",
                columns: table => new
                {
                    Id_PlanMantenimientoPreventivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePlan = table.Column<string>(type: "varchar(15)", nullable: false),
                    Id_EstadoPlan = table.Column<byte>(type: "tinyint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    isCorrectivo = table.Column<bool>(nullable: false),
                    EnEjecucion = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Plan_Mantenimiento_Preventivo", x => x.Id_PlanMantenimientoPreventivo);
                    table.ForeignKey(
                        name: "FK_T_Plan_Mantenimiento_Preventivo_T_Estado_Plan_Id_EstadoPlan",
                        column: x => x.Id_EstadoPlan,
                        principalTable: "T_Estado_Plan",
                        principalColumn: "Id_EstadoPlan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Tarea",
                columns: table => new
                {
                    Id_Tarea = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: false),
                    Clasificacion = table.Column<string>(type: "varchar(15)", nullable: true),
                    Prioridad = table.Column<string>(type: "varchar(25)", nullable: false),
                    DuracionEstimada = table.Column<int>(nullable: false),
                    TiempoPara = table.Column<int>(nullable: false),
                    Falla = table.Column<string>(type: "varchar(50)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(250)", nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Id_PlanMantenimientoPreventivo = table.Column<int>(nullable: false),
                    Id_Periodicidad = table.Column<byte>(type: "tinyint", nullable: false),
                    Id_Maquina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Tarea", x => x.Id_Tarea);
                    table.ForeignKey(
                        name: "FK_T_Tarea_T_Maquina_Id_Maquina",
                        column: x => x.Id_Maquina,
                        principalTable: "T_Maquina",
                        principalColumn: "Id_Maquina",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Tarea_T_Periodicidad_Id_Periodicidad",
                        column: x => x.Id_Periodicidad,
                        principalTable: "T_Periodicidad",
                        principalColumn: "Id_Periodicidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Tarea_T_Plan_Mantenimiento_Preventivo_Id_PlanMantenimientoPreventivo",
                        column: x => x.Id_PlanMantenimientoPreventivo,
                        principalTable: "T_Plan_Mantenimiento_Preventivo",
                        principalColumn: "Id_PlanMantenimientoPreventivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Suministro_x_Tarea",
                columns: table => new
                {
                    Id_Suministro = table.Column<int>(nullable: false),
                    Id_Tarea = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Suministro_x_Tarea", x => new { x.Id_Suministro, x.Id_Tarea });
                    table.ForeignKey(
                        name: "FK_T_Suministro_x_Tarea_T_Suministro_Id_Suministro",
                        column: x => x.Id_Suministro,
                        principalTable: "T_Suministro",
                        principalColumn: "Id_Suministro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Suministro_x_Tarea_T_Tarea_Id_Tarea",
                        column: x => x.Id_Tarea,
                        principalTable: "T_Tarea",
                        principalColumn: "Id_Tarea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Tecnico_x_Tarea",
                columns: table => new
                {
                    Id_Tecnico = table.Column<int>(nullable: false),
                    Id_Tarea = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Tecnico_x_Tarea", x => new { x.Id_Tecnico, x.Id_Tarea });
                    table.ForeignKey(
                        name: "FK_T_Tecnico_x_Tarea_T_Tarea_Id_Tarea",
                        column: x => x.Id_Tarea,
                        principalTable: "T_Tarea",
                        principalColumn: "Id_Tarea",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Tecnico_x_Tarea_T_Tecnico_Id_Tecnico",
                        column: x => x.Id_Tecnico,
                        principalTable: "T_Tecnico",
                        principalColumn: "Id_Tecnico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Orden_Servicio_Id_EstadoOS",
                table: "T_Orden_Servicio",
                column: "Id_EstadoOS");

            migrationBuilder.CreateIndex(
                name: "IX_T_Orden_Servicio_UserId",
                table: "T_Orden_Servicio",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Plan_Mantenimiento_Preventivo_Id_EstadoPlan",
                table: "T_Plan_Mantenimiento_Preventivo",
                column: "Id_EstadoPlan");

            migrationBuilder.CreateIndex(
                name: "IX_T_Suministro_Id_Bodega",
                table: "T_Suministro",
                column: "Id_Bodega");

            migrationBuilder.CreateIndex(
                name: "IX_T_Suministro_x_Tarea_Id_Tarea",
                table: "T_Suministro_x_Tarea",
                column: "Id_Tarea");

            migrationBuilder.CreateIndex(
                name: "IX_T_Tarea_Id_Maquina",
                table: "T_Tarea",
                column: "Id_Maquina");

            migrationBuilder.CreateIndex(
                name: "IX_T_Tarea_Id_Periodicidad",
                table: "T_Tarea",
                column: "Id_Periodicidad");

            migrationBuilder.CreateIndex(
                name: "IX_T_Tarea_Id_PlanMantenimientoPreventivo",
                table: "T_Tarea",
                column: "Id_PlanMantenimientoPreventivo");

            migrationBuilder.CreateIndex(
                name: "IX_T_Tecnico_x_Tarea_Id_Tarea",
                table: "T_Tecnico_x_Tarea",
                column: "Id_Tarea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Orden_Servicio");

            migrationBuilder.DropTable(
                name: "T_Suministro_x_Tarea");

            migrationBuilder.DropTable(
                name: "T_Tecnico_x_Tarea");

            migrationBuilder.DropTable(
                name: "T_Estado_OS");

            migrationBuilder.DropTable(
                name: "T_Suministro");

            migrationBuilder.DropTable(
                name: "T_Tarea");

            migrationBuilder.DropTable(
                name: "T_Tecnico");

            migrationBuilder.DropTable(
                name: "T_Bodega");

            migrationBuilder.DropTable(
                name: "T_Maquina");

            migrationBuilder.DropTable(
                name: "T_Periodicidad");

            migrationBuilder.DropTable(
                name: "T_Plan_Mantenimiento_Preventivo");

            migrationBuilder.DropTable(
                name: "T_Estado_Plan");

            migrationBuilder.AlterColumn<byte>(
                name: "Id_TipoDocumento",
                table: "T_Tipo_Documento",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
