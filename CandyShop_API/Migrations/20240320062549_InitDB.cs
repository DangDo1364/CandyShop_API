using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyShop_API.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    idCate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.idCate);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    idPro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idCate = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.idPro);
                    table.ForeignKey(
                        name: "FK_Products_Category",
                        column: x => x.idCate,
                        principalTable: "Category",
                        principalColumn: "idCate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    idImg = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idPro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.idImg);
                    table.ForeignKey(
                        name: "FK_Images_Product",
                        column: x => x.idPro,
                        principalTable: "Product",
                        principalColumn: "idPro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_idPro",
                table: "Image",
                column: "idPro");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idCate",
                table: "Product",
                column: "idCate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
