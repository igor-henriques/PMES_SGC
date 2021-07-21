using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class firstdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Militar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Posto = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Pelotao = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Funcional = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PIN = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Curso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Militar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cautela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMilitar = table.Column<int>(type: "INTEGER", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cautela = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cautela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cautela_Militar_Cautela",
                        column: x => x.Cautela,
                        principalTable: "Militar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cautela_Militar_IdMilitar",
                        column: x => x.IdMilitar,
                        principalTable: "Militar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IdMilitar = table.Column<int>(type: "INTEGER", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Militar_IdMilitar",
                        column: x => x.IdMilitar,
                        principalTable: "Militar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cautela_Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Cautela = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMaterial = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cautela_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cautela_Material_Cautela_Id_Cautela",
                        column: x => x.Id_Cautela,
                        principalTable: "Cautela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cautela_Material_Material_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cautela_Cautela",
                table: "Cautela",
                column: "Cautela");

            migrationBuilder.CreateIndex(
                name: "IX_Cautela_IdMilitar",
                table: "Cautela",
                column: "IdMilitar");

            migrationBuilder.CreateIndex(
                name: "IX_Cautela_Material_Id_Cautela",
                table: "Cautela_Material",
                column: "Id_Cautela");

            migrationBuilder.CreateIndex(
                name: "IX_Cautela_Material_IdMaterial",
                table: "Cautela_Material",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdMilitar",
                table: "Usuario",
                column: "IdMilitar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cautela_Material");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cautela");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Militar");
        }
    }
}
