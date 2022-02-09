using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ecommerce.Api.Microservice.Migrations
{
    public partial class InitialMigrationPostgreSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FistName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateBirth = table.Column<DateTime>(nullable: true),
                    AuthorGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "GradeAcademic",
                columns: table => new
                {
                    GradeAcademicId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    AcademicCenter = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    GradeAcademicGuide = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeAcademic", x => x.GradeAcademicId);
                    table.ForeignKey(
                        name: "FK_GradeAcademic_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeAcademic_AuthorId",
                table: "GradeAcademic",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeAcademic");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
