using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.PassMan
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Connections_RfCustomer",
                table: "Connections",
                column: "RfCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Customers_RfCustomer",
                table: "Connections",
                column: "RfCustomer",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Customers_RfCustomer",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_RfCustomer",
                table: "Connections");
        }
    }
}
