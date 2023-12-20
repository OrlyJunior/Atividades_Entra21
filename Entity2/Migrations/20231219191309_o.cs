using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity2.Migrations
{
    public partial class o : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Contato2Id",
                table: "Encapsulamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Local2Id",
                table: "Encapsulamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Compromisso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Encapsulamento_Contato2Id",
                table: "Encapsulamento",
                column: "Contato2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Encapsulamento_Local2Id",
                table: "Encapsulamento",
                column: "Local2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Encapsulamento_Contato_Contato2Id",
                table: "Encapsulamento",
                column: "Contato2Id",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encapsulamento_Local_Local2Id",
                table: "Encapsulamento",
                column: "Local2Id",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encapsulamento_Contato_Contato2Id",
                table: "Encapsulamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Encapsulamento_Local_Local2Id",
                table: "Encapsulamento");

            migrationBuilder.DropIndex(
                name: "IX_Encapsulamento_Contato2Id",
                table: "Encapsulamento");

            migrationBuilder.DropIndex(
                name: "IX_Encapsulamento_Local2Id",
                table: "Encapsulamento");

            migrationBuilder.DropColumn(
                name: "Contato2Id",
                table: "Encapsulamento");

            migrationBuilder.DropColumn(
                name: "Local2Id",
                table: "Encapsulamento");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Compromisso");
        }
    }
}
