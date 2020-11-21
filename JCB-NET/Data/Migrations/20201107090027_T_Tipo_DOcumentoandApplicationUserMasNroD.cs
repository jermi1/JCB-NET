using Microsoft.EntityFrameworkCore.Migrations;

namespace JCB_NET.Data.Migrations
{
    public partial class T_Tipo_DOcumentoandApplicationUserMasNroD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NroDocumento",
                table: "AspNetUsers",
                type: "varchar(30)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroDocumento",
                table: "AspNetUsers");

        }
    }
}
