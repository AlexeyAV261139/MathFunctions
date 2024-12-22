using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hardCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamValues_Params_ParamId",
                table: "ParamValues");

            migrationBuilder.DropIndex(
                name: "IX_ParamValues_ParamId",
                table: "ParamValues");

            migrationBuilder.DropColumn(
                name: "ParamId",
                table: "ParamValues");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ParamValues",
                newName: "ParamValue");

            migrationBuilder.AddColumn<string>(
                name: "ParamName",
                table: "ParamValues",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "HistoryEntityId",
                table: "Params",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ParamValue",
                table: "Params",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Params_HistoryEntityId",
                table: "Params",
                column: "HistoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Params_History_HistoryEntityId",
                table: "Params",
                column: "HistoryEntityId",
                principalTable: "History",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Params_History_HistoryEntityId",
                table: "Params");

            migrationBuilder.DropIndex(
                name: "IX_Params_HistoryEntityId",
                table: "Params");

            migrationBuilder.DropColumn(
                name: "ParamName",
                table: "ParamValues");

            migrationBuilder.DropColumn(
                name: "HistoryEntityId",
                table: "Params");

            migrationBuilder.DropColumn(
                name: "ParamValue",
                table: "Params");

            migrationBuilder.RenameColumn(
                name: "ParamValue",
                table: "ParamValues",
                newName: "Value");

            migrationBuilder.AddColumn<long>(
                name: "ParamId",
                table: "ParamValues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ParamValues_ParamId",
                table: "ParamValues",
                column: "ParamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamValues_Params_ParamId",
                table: "ParamValues",
                column: "ParamId",
                principalTable: "Params",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
