using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cueva_E_Prueba.Migrations
{
    /// <inheritdoc />
    public partial class Migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasMultiplePets = table.Column<bool>(type: "bit", nullable: false),
                    Budget = table.Column<float>(type: "real", nullable: false),
                    IdPet = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDoctor = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetOwner_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetOwner_Pet_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetOwner_IdDoctor",
                table: "PetOwner",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwner_IdPet",
                table: "PetOwner",
                column: "IdPet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetOwner");
        }
    }
}
