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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                columns: new[] { "Id", "CreationDate", "CreationUser", "DescriptionTypeBudget", "ModificationDate", "ModificationUser" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(345), "Migration", "Mercado", null, null },
                    { 2, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(458), "Migration", "Mercado diario", null, null },
                    { 3, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(467), "Migration", "Pago deudas", null, null },
                    { 4, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(470), "Migration", "Ahorros", null, null },
                    { 5, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(473), "Migration", "Inversiones", null, null },
                    { 6, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(492), "Migration", "Comidas rapidas", null, null },
                    { 7, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(496), "Migration", "Vestuario", null, null },
                    { 8, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(499), "Migration", "Electrodomesticos", null, null },
                    { 9, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(503), "Migration", "Computador", null, null },
                    { 10, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(510), "Migration", "Transporte", null, null },
                    { 11, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(513), "Migration", "Salud", null, null },
                    { 12, new DateTime(2021, 8, 18, 15, 28, 11, 55, DateTimeKind.Local).AddTicks(516), "Migration", "Arriendo", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MovementType",
                columns: new[] { "Id", "CreationDate", "CreationUser", "DescriptionTypeMovement", "ModificationDate", "ModificationUser", "MovementTypeSign" },
                values: new object[] { 1, new DateTime(2021, 8, 18, 15, 28, 11, 50, DateTimeKind.Local).AddTicks(4814), "Migration", "Salario", null, null, 1 });
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
