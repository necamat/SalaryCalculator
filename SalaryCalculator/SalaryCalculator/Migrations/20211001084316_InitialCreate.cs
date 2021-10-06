using Microsoft.EntityFrameworkCore.Migrations;

namespace SalaryCalculator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NetSalary = table.Column<double>(type: "float", nullable: false),
                    GrossSalary = table.Column<double>(type: "float", nullable: false),
                    TaxableBase = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    PioTaxEmployee = table.Column<double>(type: "float", nullable: false),
                    HeltTaxEmployee = table.Column<double>(type: "float", nullable: false),
                    UnemploymentTaxEmployee = table.Column<double>(type: "float", nullable: false),
                    PioTaxEmployer = table.Column<double>(type: "float", nullable: false),
                    HeltTaxEmployer = table.Column<double>(type: "float", nullable: false),
                    SuperGrossSalary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employee_Id",
                        column: x => x.Id,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
