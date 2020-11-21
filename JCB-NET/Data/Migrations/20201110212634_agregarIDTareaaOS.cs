using Microsoft.EntityFrameworkCore.Migrations;

namespace JCB_NET.Data.Migrations
{
    public partial class agregarIDTareaaOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Tarea",
                table: "T_Orden_Servicio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_Orden_Servicio_Id_Tarea",
                table: "T_Orden_Servicio",
                column: "Id_Tarea");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Orden_Servicio_T_Tarea_Id_Tarea",
                table: "T_Orden_Servicio",
                column: "Id_Tarea",
                principalTable: "T_Tarea",
                principalColumn: "Id_Tarea",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Orden_Servicio_T_Tarea_Id_Tarea",
                table: "T_Orden_Servicio");

            migrationBuilder.DropIndex(
                name: "IX_T_Orden_Servicio_Id_Tarea",
                table: "T_Orden_Servicio");

            migrationBuilder.DropColumn(
                name: "Id_Tarea",
                table: "T_Orden_Servicio");
        }
    }
}
