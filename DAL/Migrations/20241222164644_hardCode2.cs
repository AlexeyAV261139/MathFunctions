using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hardCode2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Params_Expressions_ExpressionEntityId",
                table: "Params");

            migrationBuilder.DropForeignKey(
                name: "FK_Params_History_HistoryEntityId",
                table: "Params");

            migrationBuilder.DropForeignKey(
                name: "FK_ParamValues_History_HistoryEntityId",
                table: "ParamValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParamValues",
                table: "ParamValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Params",
                table: "Params");

            migrationBuilder.RenameTable(
                name: "ParamValues",
                newName: "UserParams");

            migrationBuilder.RenameTable(
                name: "Params",
                newName: "AdminParams");

            migrationBuilder.RenameIndex(
                name: "IX_ParamValues_HistoryEntityId",
                table: "UserParams",
                newName: "IX_UserParams_HistoryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Params_HistoryEntityId",
                table: "AdminParams",
                newName: "IX_AdminParams_HistoryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Params_ExpressionEntityId",
                table: "AdminParams",
                newName: "IX_AdminParams_ExpressionEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserParams",
                table: "UserParams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminParams",
                table: "AdminParams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminParams_Expressions_ExpressionEntityId",
                table: "AdminParams",
                column: "ExpressionEntityId",
                principalTable: "Expressions",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminParams_Expressions_ExpressionEntityId",
                table: "AdminParams");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminParams_History_HistoryEntityId",
                table: "AdminParams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserParams_History_HistoryEntityId",
                table: "UserParams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserParams",
                table: "UserParams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminParams",
                table: "AdminParams");

            migrationBuilder.RenameTable(
                name: "UserParams",
                newName: "ParamValues");

            migrationBuilder.RenameTable(
                name: "AdminParams",
                newName: "Params");

            migrationBuilder.RenameIndex(
                name: "IX_UserParams_HistoryEntityId",
                table: "ParamValues",
                newName: "IX_ParamValues_HistoryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminParams_HistoryEntityId",
                table: "Params",
                newName: "IX_Params_HistoryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminParams_ExpressionEntityId",
                table: "Params",
                newName: "IX_Params_ExpressionEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParamValues",
                table: "ParamValues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Params",
                table: "Params",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Params_Expressions_ExpressionEntityId",
                table: "Params",
                column: "ExpressionEntityId",
                principalTable: "Expressions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Params_History_HistoryEntityId",
                table: "Params",
                column: "HistoryEntityId",
                principalTable: "History",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamValues_History_HistoryEntityId",
                table: "ParamValues",
                column: "HistoryEntityId",
                principalTable: "History",
                principalColumn: "Id");
        }
    }
}
