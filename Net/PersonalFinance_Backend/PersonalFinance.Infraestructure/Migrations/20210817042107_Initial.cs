using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalFinance.Infraestructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "BudgetType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionTypeBudget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Debt",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThirdPartyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TermInMonths = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MonthlyInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InArrears = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NumberMonthsIntArrears = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Paid = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialMovement",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociatedDebtId = table.Column<int>(type: "int", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovementValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MovementDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialMovement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBudget",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialMovementId = table.Column<int>(type: "int", nullable: false),
                    BudgetTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpectedSpending = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GeneratedSpending = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    BudgedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovementType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionTypeMovement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovementTypeSign = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saving",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThirdPartyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SavedInitialAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    SavingGoal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TermInMonths = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CurrentBalanceSaved = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InArrears = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NumberMonthsIntArrears = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SavingFinished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saving", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThirdParty",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalPersona = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdParty", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "BudgetType",
                columns: new[] { "Id", "CreationDate", "CreationUser", "DescriptionTypeBudget", "ModificationUser", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(544), "Migration", "Mercado", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2144), "Migration", "Mercado diario", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2158), "Migration", "Pago deudas", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2160), "Migration", "Ahorros", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2162), "Migration", "Inversiones", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2173), "Migration", "Comidas rapidas", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2174), "Migration", "Vestuario", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2176), "Migration", "Electrodomesticos", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2178), "Migration", "Computador", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2182), "Migration", "Transporte", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2183), "Migration", "Salud", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2021, 8, 16, 23, 21, 6, 182, DateTimeKind.Local).AddTicks(2185), "Migration", "Arriendo", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MovementType",
                columns: new[] { "Id", "CreationDate", "CreationUser", "DescriptionTypeMovement", "ModificationUser", "ModifiedDate", "MovementTypeSign" },
                values: new object[] { 1, new DateTime(2021, 8, 16, 23, 21, 6, 178, DateTimeKind.Local).AddTicks(9404), "Migration", "Salario", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Debt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FinancialMovement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MonthlyBudget",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MovementType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Saving",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ThirdParty",
                schema: "dbo");
        }
    }
}
