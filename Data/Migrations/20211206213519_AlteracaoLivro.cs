using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class AlteracaoLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroModel_AutorModel_Id",
                table: "LivroModel");

            migrationBuilder.AddColumn<Guid>(
                name: "AutorId",
                table: "LivroModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LivroModel_AutorId",
                table: "LivroModel",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroModel_AutorModel_AutorId",
                table: "LivroModel",
                column: "AutorId",
                principalTable: "AutorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroModel_AutorModel_AutorId",
                table: "LivroModel");

            migrationBuilder.DropIndex(
                name: "IX_LivroModel_AutorId",
                table: "LivroModel");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "LivroModel");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroModel_AutorModel_Id",
                table: "LivroModel",
                column: "Id",
                principalTable: "AutorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
