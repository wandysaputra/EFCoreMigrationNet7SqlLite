using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMigrationNet7SqlLite.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2500, nullable: true),
                    AuthorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("04b0fee0-1720-454f-b4cd-a60491df7e15"), "Douglas", "Adams" },
                    { new Guid("24bda992-eecc-4d01-adcb-0785283ac830"), "Stephen", "Fry" },
                    { new Guid("29d414cc-73a7-415d-aa47-d881d50eef7d"), "James", "Elroy" },
                    { new Guid("e97cd87c-d2f9-4664-aa38-632fad458171"), "George", "RR Martin" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("7e54e12f-1834-49a4-b4d6-05d62c397732"), new Guid("29d414cc-73a7-415d-aa47-d881d50eef7d"), "a 1995 novel by James Ellroy", "American Tabloid" },
                    { new Guid("88116d67-167c-4271-893e-fcf3589a3db2"), new Guid("e97cd87c-d2f9-4664-aa38-632fad458171"), "The Greek myths are amongst the best stories ever told", "Mythos" },
                    { new Guid("978567bf-0099-4b83-bf93-bafc6cb4222f"), new Guid("e97cd87c-d2f9-4664-aa38-632fad458171"), "The book that seems impossible to write", "The Winds of Winter" },
                    { new Guid("9ca0a641-b6eb-43ea-95c3-b12e6a339483"), new Guid("24bda992-eecc-4d01-adcb-0785283ac830"), "A Game of Thrones is the first novel in A Song of Ice and Fire", "A Game of Thrones" },
                    { new Guid("d0d4b0a1-9fd9-47d9-9eac-4903ed444889"), new Guid("04b0fee0-1720-454f-b4cd-a60491df7e15"), "The Hitchicker's Guide to the Galaxy", "The Hitchhiker's Guide to the Galaxy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
