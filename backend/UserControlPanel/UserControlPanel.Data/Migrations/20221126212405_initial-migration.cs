using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserControlPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighbourhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ibge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ddd = table.Column<int>(type: "int", nullable: false),
                    Siafi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAdressId = table.Column<int>(type: "int", nullable: false),
                    UserGenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserAdress_UserAdressId",
                        column: x => x.UserAdressId,
                        principalTable: "UserAdress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserGender_UserGenderId",
                        column: x => x.UserGenderId,
                        principalTable: "UserGender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserGender",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Initials" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 26, 18, 24, 5, 134, DateTimeKind.Local).AddTicks(5542), null, "Masculino", "M" },
                    { 2, new DateTime(2022, 11, 26, 18, 24, 5, 134, DateTimeKind.Local).AddTicks(5553), null, "Feminino", "F" },
                    { 3, new DateTime(2022, 11, 26, 18, 24, 5, 134, DateTimeKind.Local).AddTicks(5554), null, "Outro", "OT" },
                    { 4, new DateTime(2022, 11, 26, 18, 24, 5, 134, DateTimeKind.Local).AddTicks(5555), null, "Prefiro não dizer", "PND" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserAdressId",
                table: "User",
                column: "UserAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserGenderId",
                table: "User",
                column: "UserGenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserAdress");

            migrationBuilder.DropTable(
                name: "UserGender");
        }
    }
}
