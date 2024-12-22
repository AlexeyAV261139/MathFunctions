using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChengeVisability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParamId",
                table: "ParamValues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ExpressionEntityId",
                table: "Params",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParamValues_ParamId",
                table: "ParamValues",
                column: "ParamId");

            migrationBuilder.CreateIndex(
                name: "IX_Params_ExpressionEntityId",
                table: "Params",
                column: "ExpressionEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Params_Expressions_ExpressionEntityId",
                table: "Params",
                column: "ExpressionEntityId",
                principalTable: "Expressions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParamValues_Params_ParamId",
                table: "ParamValues",
                column: "ParamId",
                principalTable: "Params",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Params_Expressions_ExpressionEntityId",
                table: "Params");

            migrationBuilder.DropForeignKey(
                name: "FK_ParamValues_Params_ParamId",
                table: "ParamValues");

            migrationBuilder.DropIndex(
                name: "IX_ParamValues_ParamId",
                table: "ParamValues");

            migrationBuilder.DropIndex(
                name: "IX_Params_ExpressionEntityId",
                table: "Params");

            migrationBuilder.DropColumn(
                name: "ParamId",
                table: "ParamValues");

            migrationBuilder.DropColumn(
                name: "ExpressionEntityId",
                table: "Params");
        }
    }
}
