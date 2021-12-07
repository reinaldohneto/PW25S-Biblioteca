using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class AlteracaoReservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutorModel_AutorModel_AutorId",
                table: "AutorModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroModel_ReservaModel_Id",
                table: "LivroModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaModel_AutorModel_AutorId",
                table: "ReservaModel");

            migrationBuilder.DropIndex(
                name: "IX_ReservaModel_AutorId",
                table: "ReservaModel");

            migrationBuilder.DropIndex(
                name: "IX_AutorModel_AutorId",
                table: "AutorModel");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "ReservaModel");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "AutorModel");

            migrationBuilder.AddColumn<Guid>(
                name: "LivroId",
                table: "ReservaModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReservaModel_LivroId",
                table: "ReservaModel",
                column: "LivroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaModel_LivroModel_LivroId",
                table: "ReservaModel",
                column: "LivroId",
                principalTable: "LivroModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaModel_LivroModel_LivroId",
                table: "ReservaModel");

            migrationBuilder.DropIndex(
                name: "IX_ReservaModel_LivroId",
                table: "ReservaModel");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "ReservaModel");

            migrationBuilder.AddColumn<Guid>(
                name: "AutorId",
                table: "ReservaModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AutorId",
                table: "AutorModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservaModel_AutorId",
                table: "ReservaModel",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_AutorModel_AutorId",
                table: "AutorModel",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutorModel_AutorModel_AutorId",
                table: "AutorModel",
                column: "AutorId",
                principalTable: "AutorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroModel_ReservaModel_Id",
                table: "LivroModel",
                column: "Id",
                principalTable: "ReservaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaModel_AutorModel_AutorId",
                table: "ReservaModel",
                column: "AutorId",
                principalTable: "AutorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
