using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalFinance.Infraestructure.Migrations
{
    public partial class AlterColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavedInitialAmount",
                schema: "dbo",
                table: "Saving");

            migrationBuilder.RenameColumn(
                name: "NaturalPersona",
                schema: "dbo",
                table: "ThirdParty",
                newName: "NaturalPerson");

            migrationBuilder.AddColumn<string>(
                name: "SavingDescription",
                schema: "dbo",
                table: "Saving",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 340, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MovementType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 23, 41, 52, 326, DateTimeKind.Local).AddTicks(3681));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavingDescription",
                schema: "dbo",
                table: "Saving");

            migrationBuilder.RenameColumn(
                name: "NaturalPerson",
                schema: "dbo",
                table: "ThirdParty",
                newName: "NaturalPersona");

            migrationBuilder.AddColumn<decimal>(
                name: "SavedInitialAmount",
                schema: "dbo",
                table: "Saving",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5304));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5308));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "BudgetType",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5311));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MovementType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 1, 31, 23, 57, DateTimeKind.Local).AddTicks(4314));
        }
    }
}
