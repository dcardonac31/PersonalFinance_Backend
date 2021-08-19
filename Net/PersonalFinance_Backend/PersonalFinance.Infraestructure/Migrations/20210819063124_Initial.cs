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
                    table.ForeignKey(
                        name: "FK_Debt_ThirdPartyId",
                        column: x => x.ThirdPartyId,
                        principalSchema: "dbo",
                        principalTable: "ThirdParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Saving_ThirdPartyId",
                        column: x => x.ThirdPartyId,
                        principalSchema: "dbo",
                        principalTable: "ThirdParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebtDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    InterestValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    AmortizedCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    OutstandingCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtDetail_DebtId",
                        column: x => x.DebtId,
                        principalSchema: "dbo",
                        principalTable: "Debt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialMovement",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementTypeId = table.Column<int>(type: "int", nullable: false),
                    AssociatedDebtId = table.Column<int>(type: "int", nullable: true),
                    AssociatedSavingId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_FinancialMovement_AssociatedDebtId",
                        column: x => x.AssociatedDebtId,
                        principalSchema: "dbo",
                        principalTable: "Debt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialMovement_AssociatedSavingId",
                        column: x => x.AssociatedSavingId,
                        principalSchema: "dbo",
                        principalTable: "Saving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialMovement_MovementTypeId",
                        column: x => x.MovementTypeId,
                        principalSchema: "dbo",
                        principalTable: "MovementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SavingId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Retired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingDetail_SavingId",
                        column: x => x.SavingId,
                        principalSchema: "dbo",
                        principalTable: "Saving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_MonthlyBudget_BudgetTypeId",
                        column: x => x.BudgetTypeId,
                        principalSchema: "dbo",
                        principalTable: "BudgetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlyBudget_FinancialMovementId",
                        column: x => x.FinancialMovementId,
                        principalSchema: "dbo",
                        principalTable: "FinancialMovement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "BudgetType",
                columns: new[] { "Id", "CreationDate", "CreationUser", "DescriptionTypeBudget", "ModificationDate", "ModificationUser" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5211), "Migration", "Mercado", null, null },
                    { 2, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5279), "Migration", "Mercado diario", null, null },
                    { 3, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5283), "Migration", "Pago deudas", null, null },
                    { 4, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5285), "Migration", "Ahorros", null, null },
                    { 5, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5288), "Migration", "Inversiones", null, null },
                    { 6, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5297), "Migration", "Comidas rapidas", null, null },
                    { 7, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5299), "Migration", "Vestuario", null, null },
                    { 8, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5302), "Migration", "Electrodomesticos", null, null },
                    { 9, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5304), "Migration", "Computador", null, null },
                    { 10, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5308), "Migration", "Transporte", null, null },
                    { 11, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5310), "Migration", "Salud", null, null },
                    { 12, new DateTime(2021, 8, 19, 1, 31, 23, 60, DateTimeKind.Local).AddTicks(5311), "Migration", "Arriendo", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MovementType",
                columns: new[] { "Id", "CreationDate", "CreationUser", "DescriptionTypeMovement", "ModificationDate", "ModificationUser", "MovementTypeSign" },
                values: new object[] { 1, new DateTime(2021, 8, 19, 1, 31, 23, 57, DateTimeKind.Local).AddTicks(4314), "Migration", "Salario", null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Debt_CreationDate",
                schema: "dbo",
                table: "Debt",
                column: "CreationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_ThirdPartyId",
                schema: "dbo",
                table: "Debt",
                column: "ThirdPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_DebtDetail_CreationDate",
                schema: "dbo",
                table: "DebtDetail",
                column: "CreationDate");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_DebtDetail_DebtId",
                schema: "dbo",
                table: "DebtDetail",
                column: "DebtId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMovement_AssociatedDebtId",
                schema: "dbo",
                table: "FinancialMovement",
                column: "AssociatedDebtId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMovement_AssociatedSavingId",
                schema: "dbo",
                table: "FinancialMovement",
                column: "AssociatedSavingId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMovement_CreationDate",
                schema: "dbo",
                table: "FinancialMovement",
                column: "CreationDate");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMovement_MovementTypeId",
                schema: "dbo",
                table: "FinancialMovement",
                column: "MovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBudget_BudgetTypeId",
                schema: "dbo",
                table: "MonthlyBudget",
                column: "BudgetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBudget_CreationDate",
                schema: "dbo",
                table: "MonthlyBudget",
                column: "CreationDate");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBudget_FinancialMovementId",
                schema: "dbo",
                table: "MonthlyBudget",
                column: "FinancialMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Saving_CreationDate",
                schema: "dbo",
                table: "Saving",
                column: "CreationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Saving_ThirdPartyId",
                schema: "dbo",
                table: "Saving",
                column: "ThirdPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SavingDetail_CreationDate",
                schema: "dbo",
                table: "SavingDetail",
                column: "CreationDate");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SavingDetail_SavingId",
                schema: "dbo",
                table: "SavingDetail",
                column: "SavingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MonthlyBudget",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SavingDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BudgetType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FinancialMovement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Debt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Saving",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MovementType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ThirdParty",
                schema: "dbo");
        }
    }
}
