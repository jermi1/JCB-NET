using Microsoft.EntityFrameworkCore.Migrations;

namespace JCB_NET.Data.Migrations
{
    public partial class añadiendoCampoZonaaT_Maquina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "Zona",
                table: "T_Maquina",
                type: "varchar(25)",
                nullable: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zona",
                table: "T_Maquina");

        }
    }
}
