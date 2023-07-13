using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gov.Import.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faps",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    totalElementsInteger = table.Column<int>(type: "integer", nullable: false),
                    totalElements = table.Column<int>(type: "integer", nullable: false),
                    totalPages = table.Column<int>(type: "integer", nullable: false),
                    last = table.Column<bool>(type: "boolean", nullable: false),
                    first = table.Column<bool>(type: "boolean", nullable: false),
                    numberOfElements = table.Column<int>(type: "integer", nullable: false),
                    sort = table.Column<string>(type: "text", nullable: true),
                    size = table.Column<int>(type: "integer", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    financialYear = table.Column<string>(type: "text", nullable: true),
                    firstYearPeriod = table.Column<string>(type: "text", nullable: true),
                    secondYearPeriod = table.Column<string>(type: "text", nullable: true),
                    dateApprovel = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<string>(type: "text", nullable: true),
                    lastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    founder = table.Column<string>(type: "text", nullable: true),
                    founderAgencyId = table.Column<string>(type: "text", nullable: true),
                    founderGlavaCode = table.Column<string>(type: "text", nullable: true),
                    fullClientName = table.Column<string>(type: "text", nullable: true),
                    clientRegionName = table.Column<string>(type: "text", nullable: true),
                    clientRegionCode = table.Column<string>(type: "text", nullable: true),
                    isArchive = table.Column<bool>(type: "boolean", nullable: false),
                    summaryRegistryCode = table.Column<string>(type: "text", nullable: true),
                    inn = table.Column<string>(type: "text", nullable: true),
                    kpp = table.Column<string>(type: "text", nullable: true),
                    okeiSymbol = table.Column<string>(type: "text", nullable: true),
                    okeiCode = table.Column<string>(type: "text", nullable: true),
                    orgType = table.Column<string>(type: "text", nullable: true),
                    sumRealEstate = table.Column<float>(type: "real", nullable: true),
                    sumRealEstateResidual = table.Column<float>(type: "real", nullable: true),
                    sumValuableProperty = table.Column<float>(type: "real", nullable: true),
                    sumValuablePropertyResidual = table.Column<float>(type: "real", nullable: true),
                    sumBalanceNoFinancial = table.Column<float>(type: "real", nullable: true),
                    cash = table.Column<float>(type: "real", nullable: true),
                    accountsCash = table.Column<float>(type: "real", nullable: true),
                    depositCash = table.Column<float>(type: "real", nullable: true),
                    others = table.Column<float>(type: "real", nullable: true),
                    sumDepthIncome = table.Column<float>(type: "real", nullable: true),
                    sumDepthExpenses = table.Column<float>(type: "real", nullable: true),
                    sumFinancialActives = table.Column<float>(type: "real", nullable: true),
                    debentures = table.Column<float>(type: "real", nullable: true),
                    kredit = table.Column<float>(type: "real", nullable: true),
                    sumDelayedPayable = table.Column<float>(type: "real", nullable: true),
                    sumObligations = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentName = table.Column<string>(type: "text", nullable: true),
                    PlanpaymentLineCode = table.Column<string>(type: "text", nullable: true),
                    PlanpaymentKbk = table.Column<string>(type: "text", nullable: true),
                    PlanpaymentTotal = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentFinancialProvision = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentFinancialInsurance = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentProvision781 = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentCapitalInvestment = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentHealthInsurance = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentServiceGrant = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentServiceTotal = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainName = table.Column<string>(type: "text", nullable: true),
                    PlanpaymentMainLineCode = table.Column<string>(type: "text", nullable: true),
                    PlanpaymentMainKbk = table.Column<string>(type: "text", nullable: true),
                    PlanpaymentMainTotal = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainFinancialProvision = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainFinancialInsurance = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainProvision781 = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainCapitalInvestment = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainHealthInsurance = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainServiceGrant = table.Column<float>(type: "real", nullable: true),
                    PlanpaymentMainServiceTotal = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentYear = table.Column<int>(type: "integer", nullable: true),
                    ExpensepaymentName = table.Column<string>(type: "text", nullable: true),
                    ExpensepaymentLineCode = table.Column<string>(type: "text", nullable: true),
                    ExpensepaymentNextYearFz44Sum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentNextYearFz223Sum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentNextYearTotalSum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentFirstPlanYearFz44Sum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentFirstPlanYearFz223Sum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentFirstPlanYearTotalSum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentSecondPlanYearFz44Sum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentSecondPlanYearFz223Sum = table.Column<float>(type: "real", nullable: true),
                    ExpensepaymentSecondPlanYearTotalSum = table.Column<float>(type: "real", nullable: true),
                    TemporaryresourceName = table.Column<string>(type: "text", nullable: true),
                    TemporaryresourceLineCode = table.Column<string>(type: "text", nullable: true),
                    TemporaryresourceTotal = table.Column<float>(type: "real", nullable: true),
                    ReferenceName = table.Column<string>(type: "text", nullable: true),
                    ReferenceLineCode = table.Column<string>(type: "text", nullable: true),
                    ReferenceTotal = table.Column<float>(type: "real", nullable: true),
                    AttachmentFileName = table.Column<string>(type: "text", nullable: true),
                    AttachmentFileSize = table.Column<string>(type: "text", nullable: true),
                    AttachmentDocumentDate = table.Column<string>(type: "text", nullable: true),
                    AttachmentPublishDate = table.Column<string>(type: "text", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faps", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faps");
        }
    }
}
