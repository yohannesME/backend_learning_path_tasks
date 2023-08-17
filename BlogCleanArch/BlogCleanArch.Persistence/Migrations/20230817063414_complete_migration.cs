using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogCleanArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class complete_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Test Content 1", new DateTime(2023, 8, 17, 6, 34, 14, 621, DateTimeKind.Utc).AddTicks(112), "Test Post 1", new DateTime(2023, 8, 17, 6, 34, 14, 621, DateTimeKind.Utc).AddTicks(113) },
                    { 2, "Test Content 2", new DateTime(2023, 8, 17, 6, 34, 14, 621, DateTimeKind.Utc).AddTicks(116), "Test Post 2", new DateTime(2023, 8, 17, 6, 34, 14, 621, DateTimeKind.Utc).AddTicks(117) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "PostId", "Text", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7604), 1, "Test Comment 1", new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7609) },
                    { 2, new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7613), 1, "Test Comment 2", new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7613) },
                    { 3, new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7615), 2, "Test Comment 3", new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7615) },
                    { 4, new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7617), 2, "Test Comment 4", new DateTime(2023, 8, 17, 6, 34, 14, 620, DateTimeKind.Utc).AddTicks(7616) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
