using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParametrValues_Parametros_ParametrId",
                table: "ParametrValues");

            migrationBuilder.DropIndex(
                name: "IX_ParametrValues_ParametrId",
                table: "ParametrValues");

            migrationBuilder.DropColumn(
                name: "ParametrId",
                table: "ParametrValues");

            migrationBuilder.AddColumn<string>(
                name: "Parametr",
                table: "ParametrValues",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parametr",
                table: "ParametrValues");

            migrationBuilder.AddColumn<long>(
                name: "ParametrId",
                table: "ParametrValues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ParametrValues_ParametrId",
                table: "ParametrValues",
                column: "ParametrId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParametrValues_Parametros_ParametrId",
                table: "ParametrValues",
                column: "ParametrId",
                principalTable: "Parametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
