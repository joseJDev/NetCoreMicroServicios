using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Micro.Book.Migrations
{
    public partial class MigrationBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookLibrary",
                columns: table => new
                {
                    BookLibraryId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    AuthorBook = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLibrary", x => x.BookLibraryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLibrary");
        }
    }
}
