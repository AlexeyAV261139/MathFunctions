using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class endp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Expressions_ExpressionId",
                table: "History");

            migrationBuilder.DropTable(
                name: "AdminParamsEntityHistoryEntity");

            migrationBuilder.DropTable(
                name: "HistoryEntityUserParamsEntity");

            migrationBuilder.DropTable(
                name: "AdminParams");

            migrationBuilder.DropTable(
                name: "UserParams");

            migrationBuilder.DropTable(
                name: "Expressions");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "ExpressionId",
                table: "History",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_History_ExpressionId",
                table: "History",
                newName: "IX_History_UserId");

            migrationBuilder.AddColumn<long>(
                name: "FormulaId",
                table: "History",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Furmulas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FormulaString = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furmulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FormulaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parametros_Furmulas_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Furmulas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParametrValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParametrId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    HistoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametrValues_History_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "History",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParametrValues_Parametros_ParametrId",
                        column: x => x.ParametrId,
                        principalTable: "Parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_FormulaId",
                table: "History",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_FormulaId",
                table: "Parametros",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametrValues_HistoryId",
                table: "ParametrValues",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametrValues_ParametrId",
                table: "ParametrValues",
                column: "ParametrId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Furmulas_FormulaId",
                table: "History",
                column: "FormulaId",
                principalTable: "Furmulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Users_UserId",
                table: "History",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Furmulas_FormulaId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Users_UserId",
                table: "History");

            migrationBuilder.DropTable(
                name: "ParametrValues");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Furmulas");

            migrationBuilder.DropIndex(
                name: "IX_History_FormulaId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "History",
                newName: "ExpressionId");

            migrationBuilder.RenameIndex(
                name: "IX_History_UserId",
                table: "History",
                newName: "IX_History_ExpressionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "History",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Expressions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpressionString = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expressions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserParams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParamName = table.Column<string>(type: "text", nullable: false),
                    ParamValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminParams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpressionEntityId = table.Column<long>(type: "bigint", nullable: true),
                    ParamName = table.Column<string>(type: "text", nullable: false),
                    ParamValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminParams_Expressions_ExpressionEntityId",
                        column: x => x.ExpressionEntityId,
                        principalTable: "Expressions",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_AdminParams_ExpressionEntityId",
                table: "AdminParams",
                column: "ExpressionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminParamsEntityHistoryEntity_HistoriesId",
                table: "AdminParamsEntityHistoryEntity",
                column: "HistoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEntityUserParamsEntity_UserParamsId",
                table: "HistoryEntityUserParamsEntity",
                column: "UserParamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Expressions_ExpressionId",
                table: "History",
                column: "ExpressionId",
                principalTable: "Expressions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
