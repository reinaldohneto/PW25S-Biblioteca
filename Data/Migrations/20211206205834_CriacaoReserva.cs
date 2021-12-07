using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class CriacaoReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "LivroModel");

            migrationBuilder.DropColumn(
                name: "QuantidadeLocado",
                table: "LivroModel");

            migrationBuilder.CreateTable(
                name: "ReservaModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeLocador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaModel_AutorModel_AutorId",
                        column: x => x.AutorId,
                        principalTable: "AutorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaModel_AutorId",
                table: "ReservaModel",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroModel_ReservaModel_Id",
                table: "LivroModel",
                column: "Id",
                principalTable: "ReservaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroModel_ReservaModel_Id",
                table: "LivroModel");

            migrationBuilder.DropTable(
                name: "ReservaModel");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "LivroModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeLocado",
                table: "LivroModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
