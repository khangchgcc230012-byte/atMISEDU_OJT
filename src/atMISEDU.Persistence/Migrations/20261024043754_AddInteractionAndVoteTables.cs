using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atMISEDU.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInteractionAndVoteTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleDiscussionInteractions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscussionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDiscussionInteractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleInteractions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntnType = table.Column<int>(type: "int", nullable: false),
                    InteractionType = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleInteractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteValue = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catalogUnit",
                columns: table => new
                {
                    unitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cugID = table.Column<int>(type: "int", nullable: false),
                    unitCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogUnit", x => x.unitID);
                });

            migrationBuilder.CreateTable(
                name: "hubsChannel",
                columns: table => new
                {
                    channelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    isActived = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hubsChannel", x => x.channelID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleDiscussionInteractions");

            migrationBuilder.DropTable(
                name: "ArticleInteractions");

            migrationBuilder.DropTable(
                name: "ArticleVotes");

            migrationBuilder.DropTable(
                name: "catalogUnit");

            migrationBuilder.DropTable(
                name: "hubsChannel");
        }
    }
}
