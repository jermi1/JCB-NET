using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JCB_NET.Data.Migrations
{
    public partial class T_Tipo_DOcumentoandApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApeMaterno",
                table: "AspNetUsers",
                type: "varchar(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApePaterno",
                table: "AspNetUsers",
                type: "varchar(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                type: "varchar(80)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Id_TipoDocumento",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "T_Tipo_Documento",
                columns: table => new
                {
                    Id_TipoDocumento = table.Column<byte>(type: "tinyint", nullable: false),
                    Valor = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Tipo_Documento", x => x.Id_TipoDocumento);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id_TipoDocumento",
                table: "AspNetUsers",
                column: "Id_TipoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_T_Tipo_Documento_Id_TipoDocumento",
                table: "AspNetUsers",
                column: "Id_TipoDocumento",
                principalTable: "T_Tipo_Documento",
                principalColumn: "Id_TipoDocumento",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_T_Tipo_Documento_Id_TipoDocumento",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "T_Tipo_Documento");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Id_TipoDocumento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApeMaterno",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApePaterno",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id_TipoDocumento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
