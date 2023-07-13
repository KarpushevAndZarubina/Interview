using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gov.Import.Data;
public class FapData
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public int totalElementsInteger { get; set; }
    public int totalElements { get; set; }
    public int totalPages { get; set; }
    public bool last { get; set; }
    public bool first { get; set; }
    public int numberOfElements { get; set; }
    public string? sort { get; set; }
    public int size { get; set; }
    public int number { get; set; }
    public string? financialYear { get; set; }
    public string? firstYearPeriod { get; set; }
    public string? secondYearPeriod { get; set; }
    public string? dateApprovel { get; set; }
    public string? date { get; set; }
    public DateTime lastUpdate { get; set; }
    public string? founder { get; set; }
    public string? founderAgencyId { get; set; }
    public string? founderGlavaCode { get; set; }
    public string? fullClientName { get; set; }
    public string? clientRegionName { get; set; }
    public string? clientRegionCode { get; set; }
    public bool isArchive { get; set; }
    public string? summaryRegistryCode { get; set; }
    public string? inn { get; set; }
    public string? kpp { get; set; }
    public string? okeiSymbol { get; set; }
    public string? okeiCode { get; set; }
    public string? orgType { get; set; }
    public float? sumRealEstate { get; set; }
    public float? sumRealEstateResidual { get; set; }
    public float? sumValuableProperty { get; set; }
    public float? sumValuablePropertyResidual { get; set; }
    public float? sumBalanceNoFinancial { get; set; }
    public float? cash { get; set; }
    public float? accountsCash { get; set; }
    public float? depositCash { get; set; }
    public float? others { get; set; }
    public float? sumDepthIncome { get; set; }
    public float? sumDepthExpenses { get; set; }
    public float? sumFinancialActives { get; set; }
    public float? debentures { get; set; }
    public float? kredit { get; set; }
    public float? sumDelayedPayable { get; set; }
    public float? sumObligations { get; set; }

    public string? PlanpaymentName { get; set; }
    public string? PlanpaymentLineCode { get; set; }
    public string? PlanpaymentKbk { get; set; }
    public float? PlanpaymentTotal { get; set; }
    public float? PlanpaymentFinancialProvision { get; set; }
    public float? PlanpaymentFinancialInsurance { get; set; }
    public float? PlanpaymentProvision781 { get; set; }
    public float? PlanpaymentCapitalInvestment { get; set; }
    public float? PlanpaymentHealthInsurance { get; set; }
    public float? PlanpaymentServiceGrant { get; set; }
    public float? PlanpaymentServiceTotal { get; set; }
    public string? PlanpaymentMainName { get; set; }
    public string? PlanpaymentMainLineCode { get; set; }
    public string? PlanpaymentMainKbk { get; set; }
    public float? PlanpaymentMainTotal { get; set; }
    public float? PlanpaymentMainFinancialProvision { get; set; }
    public float? PlanpaymentMainFinancialInsurance { get; set; }
    public float? PlanpaymentMainProvision781 { get; set; }
    public float? PlanpaymentMainCapitalInvestment { get; set; }
    public float? PlanpaymentMainHealthInsurance { get; set; }
    public float? PlanpaymentMainServiceGrant { get; set; }
    public float? PlanpaymentMainServiceTotal { get; set; }
    public int? ExpensepaymentYear { get; set; }
    public string? ExpensepaymentName { get; set; }
    public string? ExpensepaymentLineCode { get; set; }
    public float? ExpensepaymentNextYearFz44Sum { get; set; }
    public float? ExpensepaymentNextYearFz223Sum { get; set; }
    public float? ExpensepaymentNextYearTotalSum { get; set; }
    public float? ExpensepaymentFirstPlanYearFz44Sum { get; set; }
    public float? ExpensepaymentFirstPlanYearFz223Sum { get; set; }
    public float? ExpensepaymentFirstPlanYearTotalSum { get; set; }
    public float? ExpensepaymentSecondPlanYearFz44Sum { get; set; }
    public float? ExpensepaymentSecondPlanYearFz223Sum { get; set; }
    public float? ExpensepaymentSecondPlanYearTotalSum { get; set; }
    public string? TemporaryresourceName { get; set; }
    public string? TemporaryresourceLineCode { get; set; }
    public float? TemporaryresourceTotal { get; set; }
    public string? ReferenceName { get; set; }
    public string? ReferenceLineCode { get; set; }
    public float? ReferenceTotal { get; set; }
    public string? AttachmentFileName { get; set; }
    public string? AttachmentFileSize { get; set; }
    public string? AttachmentDocumentDate { get; set; }
    public string? AttachmentPublishDate { get; set; }
    public string? AttachmentUrl { get; set; }
}
