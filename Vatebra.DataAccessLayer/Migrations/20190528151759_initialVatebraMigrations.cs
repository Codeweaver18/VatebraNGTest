using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vatebra.DataAccessLayer.Migrations
{
    public partial class initialVatebraMigrations : Migration
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
                name: "Match",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    MatchName = table.Column<string>(nullable: true),
                    MatchVenue = table.Column<string>(nullable: true),
                    MatchDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    TeamName = table.Column<string>(nullable: true),
                    TeamDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
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
                    table.PrimaryKey("PK_BookCopies", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_bookId",
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

            migrationBuilder.CreateTable(
                name: "Footballers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PlayerPosition = table.Column<string>(nullable: true),
                    DateJoined = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Footballers_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchGoals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    dateModified = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    FootballersId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: true),
                    goalDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchGoals", x => x.id);
                    table.ForeignKey(
                        name: "FK_MatchGoals_Footballers_FootballersId",
                        column: x => x.FootballersId,
                        principalTable: "Footballers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchGoals_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_bookId",
                table: "BookCopies",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksBorrowed_bookId",
                table: "BooksBorrowed",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubscriptionDetails_bookId",
                table: "BookSubscriptionDetails",
                column: "bookId",
                unique: true,
                filter: "[bookId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Footballers_TeamId",
                table: "Footballers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGoals_FootballersId",
                table: "MatchGoals",
                column: "FootballersId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGoals_MatchId",
                table: "MatchGoals",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "BooksBorrowed");

            migrationBuilder.DropTable(
                name: "BookSubscriptionDetails");

            migrationBuilder.DropTable(
                name: "MatchGoals");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Footballers");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
