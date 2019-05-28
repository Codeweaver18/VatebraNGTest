using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vatebra.DataAccessLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    bookName = table.Column<string>(nullable: true),
                    bookTitle = table.Column<string>(nullable: true),
                    BookAuthor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BoBookCopiesks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    bookId = table.Column<int>(nullable: true),
                    yearPublished = table.Column<string>(nullable: true),
                    bookAbstract = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    versionTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoBookCopiesks", x => x.id);
                    table.ForeignKey(
                        name: "FK_BoBookCopiesks_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BooksBorrowed",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    bookId = table.Column<int>(nullable: true),
                    ApprovedById = table.Column<string>(nullable: true),
                    dateBorrowed = table.Column<DateTime>(nullable: false),
                    dueReturnedDate = table.Column<DateTime>(nullable: false),
                    comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksBorrowed", x => x.id);
                    table.ForeignKey(
                        name: "FK_BooksBorrowed_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookSubscriptionDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    bookId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isfree = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubscriptionDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookSubscriptionDetails_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoBookCopiesks_bookId",
                table: "BoBookCopiesks",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksBorrowed_bookId",
                table: "BooksBorrowed",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubscriptionDetails_bookId",
                table: "BookSubscriptionDetails",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoBookCopiesks");

            migrationBuilder.DropTable(
                name: "BooksBorrowed");

            migrationBuilder.DropTable(
                name: "BookSubscriptionDetails");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
