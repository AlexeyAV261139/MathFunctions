using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hyctoryBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminParams_History_HistoryEntityId",
                table: "AdminParams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserParams_History_HistoryEntityId",
                table: "UserParams");

            migrationBuilder.DropIndex(
                name: "IX_UserParams_HistoryEntityId",
                table: "UserParams");

            migrationBuilder.DropIndex(
                name: "IX_AdminParams_HistoryEntityId",
                table: "AdminParams");

            migrationBuilder.DropColumn(
                name: "HistoryEntityId",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "HistoryEntityId",
                table: "AdminParams");

            migrationBuilder.CreateTable(
                name: "AdminParamsEntityHistoryEntity",
                columns: table => new
                {
                    ApminParamsId = table.Column<long>(type: "bigint", nullable: false),
                    HistoriesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminParamsEntityHistoryEntity", x => new { x.ApminParamsId, x.HistoriesId });
                    table.ForeignKey(
                        name: "FK_AdminParamsEntityHistoryEntity_AdminParams_ApminParamsId",
                        column: x => x.ApminParamsId,
                        principalTable: "AdminParams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminParamsEntityHistoryEntity_History_HistoriesId",
                        column: x => x.HistoriesId,
                        principalTable: "History",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryEntityUserParamsEntity",
                columns: table => new
                {
                    HistoriesId = table.Column<long>(type: "bigint", nullable: false),
                    UserParamsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryEntityUserParamsEntity", x => new { x.HistoriesId, x.UserParamsId });
                    table.ForeignKey(
                        name: "FK_HistoryEntityUserParamsEntity_History_HistoriesId",
                        column: x => x.HistoriesId,
                        principalTable: "History",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryEntityUserParamsEntity_UserParams_UserParamsId",
                        column: x => x.UserParamsId,
                        principalTable: "UserParams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminParamsEntityHistoryEntity_HistoriesId",
                table: "AdminParamsEntityHistoryEntity",
                column: "HistoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEntityUserParamsEntity_UserParamsId",
                table: "HistoryEntityUserParamsEntity",
                column: "UserParamsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminParamsEntityHistoryEntity");

            migrationBuilder.DropTable(
                name: "HistoryEntityUserParamsEntity");

            migrationBuilder.AddColumn<long>(
                name: "HistoryEntityId",
                table: "UserParams",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HistoryEntityId",
                table: "AdminParams",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserParams_HistoryEntityId",
                table: "UserParams",
                column: "HistoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminParams_HistoryEntityId",
                table: "AdminParams",
                column: "HistoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminParams_History_HistoryEntityId",
                table: "AdminParams",
                column: "HistoryEntityId",
                principalTable: "History",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserParams_History_HistoryEntityId",
                table: "UserParams",
                column: "HistoryEntityId",
                principalTable: "History",
                principalColumn: "Id");
        }
    }
}
