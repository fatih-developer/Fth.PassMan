using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.PassMan
{
    /// <inheritdoc />
    public partial class addTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfCalendar = table.Column<int>(type: "int", nullable: false),
                    RfCustomer = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<bool>(type: "bit", nullable: false),
                    End = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Calendars_RfCalendar",
                        column: x => x.RfCalendar,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Plans_Customers_RfCustomer",
                        column: x => x.RfCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfCustomer = table.Column<int>(type: "int", nullable: false),
                    RfPlan = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrevData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warning = table.Column<bool>(type: "bit", nullable: false),
                    Todo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Controls_Customers_RfCustomer",
                        column: x => x.RfCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Controls_Plans_RfPlan",
                        column: x => x.RfPlan,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Controls_RfCustomer",
                table: "Controls",
                column: "RfCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_RfPlan",
                table: "Controls",
                column: "RfPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_RfCalendar",
                table: "Plans",
                column: "RfCalendar");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_RfCustomer",
                table: "Plans",
                column: "RfCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Calendars");
        }
    }
}
