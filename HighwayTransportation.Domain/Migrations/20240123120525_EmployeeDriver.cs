using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighwayTransportation.Domain.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Employees_DriverId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVehicle_Employees_DriversId",
                table: "EmployeeVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_DriverId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Expenses",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_DriverId",
                table: "Expenses",
                newName: "IX_Expenses_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "DriversId",
                table: "EmployeeVehicle",
                newName: "EmployeesId");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Deliveries",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_DriverId",
                table: "Deliveries",
                newName: "IX_Deliveries_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Employees_EmployeeId",
                table: "Deliveries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVehicle_Employees_EmployeesId",
                table: "EmployeeVehicle",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Employees_EmployeeId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVehicle_Employees_EmployeesId",
                table: "EmployeeVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Expenses",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expenses",
                newName: "IX_Expenses_DriverId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeVehicle",
                newName: "DriversId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Deliveries",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_EmployeeId",
                table: "Deliveries",
                newName: "IX_Deliveries_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Employees_DriverId",
                table: "Deliveries",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVehicle_Employees_DriversId",
                table: "EmployeeVehicle",
                column: "DriversId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_DriverId",
                table: "Expenses",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
