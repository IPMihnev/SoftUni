using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballLeague.Domain.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "match",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_team_points = table.Column<int>(type: "int", nullable: false),
                    second_team_points = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MatchEntityTeamEntity",
                columns: table => new
                {
                    MatchesId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEntityTeamEntity", x => new { x.MatchesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_MatchEntityTeamEntity_match_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "match",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchEntityTeamEntity_teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchEntityTeamEntity_TeamsId",
                table: "MatchEntityTeamEntity",
                column: "TeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchEntityTeamEntity");

            migrationBuilder.DropTable(
                name: "match");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
