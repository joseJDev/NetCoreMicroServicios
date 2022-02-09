using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Ecommerce.Micro.CarShop.Migrations
{
    public partial class MigrationCarShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarShopSession",
                columns: table => new
                {
                    CarShopSessionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarShopSession", x => x.CarShopSessionId);
                });

            migrationBuilder.CreateTable(
                name: "CarShopSessionDetail",
                columns: table => new
                {
                    CarShopSessionDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProductSelected = table.Column<string>(nullable: true),
                    CarShopSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarShopSessionDetail", x => x.CarShopSessionDetailId);
                    table.ForeignKey(
                        name: "FK_CarShopSessionDetail_CarShopSession_CarShopSessionId",
                        column: x => x.CarShopSessionId,
                        principalTable: "CarShopSession",
                        principalColumn: "CarShopSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarShopSessionDetail_CarShopSessionId",
                table: "CarShopSessionDetail",
                column: "CarShopSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarShopSessionDetail");

            migrationBuilder.DropTable(
                name: "CarShopSession");
        }
    }
}
