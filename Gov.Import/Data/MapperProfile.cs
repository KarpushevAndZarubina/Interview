using AutoMapper;

using Gov.ApiClient.Model;

namespace Gov.Import.Data;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Common, FapData>();
        CreateMap<Indicatorsoffinancialcondition, FapData>();

        CreateMap<Planpaymentindex, FapData>()
            .ForMember(d => d.PlanpaymentName, opt => opt.MapFrom(s => s.name))
            .ForMember(d => d.PlanpaymentLineCode, opt => opt.MapFrom(s => s.lineCode))
            .ForMember(d => d.PlanpaymentKbk, opt => opt.MapFrom(s => s.kbk))
            .ForMember(d => d.PlanpaymentTotal, opt => opt.MapFrom(s => s.total))
            .ForMember(d => d.PlanpaymentFinancialProvision, opt => opt.MapFrom(s => s.financialProvision))
            .ForMember(d => d.PlanpaymentFinancialInsurance, opt => opt.MapFrom(s => s.financialInsurance))
            .ForMember(d => d.PlanpaymentProvision781, opt => opt.MapFrom(s => s.provision781))
            .ForMember(d => d.PlanpaymentCapitalInvestment, opt => opt.MapFrom(s => s.capitalInvestment))
            .ForMember(d => d.PlanpaymentHealthInsurance, opt => opt.MapFrom(s => s.healthInsurance))
            .ForMember(d => d.PlanpaymentServiceGrant, opt => opt.MapFrom(s => s.serviceGrant))
            .ForMember(d => d.PlanpaymentServiceTotal, opt => opt.MapFrom(s => s.serviceTotal));

        CreateMap<Planpaymentindexesmain, FapData>()
            .ForMember(d => d.PlanpaymentMainKbk, opt => opt.MapFrom(s => s.kbk))
            .ForMember(d => d.PlanpaymentMainHealthInsurance, opt => opt.MapFrom(s => s.healthInsurance))
            .ForMember(d => d.PlanpaymentMainFinancialInsurance, opt => opt.MapFrom(s => s.financialInsurance))
            .ForMember(d => d.PlanpaymentMainServiceGrant, opt => opt.MapFrom(s => s.serviceGrant))
            .ForMember(d => d.PlanpaymentMainCapitalInvestment, opt => opt.MapFrom(s => s.capitalInvestment))
            .ForMember(d => d.PlanpaymentMainFinancialProvision, opt => opt.MapFrom(s => s.financialProvision))
            .ForMember(d => d.PlanpaymentMainProvision781, opt => opt.MapFrom(s => s.provision781))
            .ForMember(d => d.PlanpaymentMainLineCode, opt => opt.MapFrom(s => s.lineCode))
            .ForMember(d => d.PlanpaymentMainName, opt => opt.MapFrom(s => s.name))
            .ForMember(d => d.PlanpaymentMainServiceTotal, opt => opt.MapFrom(s => s.serviceTotal))
            .ForMember(d => d.PlanpaymentMainTotal, opt => opt.MapFrom(s => s.total));

        CreateMap<Expensepaymentindex, FapData>()
           .ForMember(d => d.ExpensepaymentName, opt => opt.MapFrom(s => s.name))
           .ForMember(d => d.ExpensepaymentYear, opt => opt.MapFrom(s => s.year))
           .ForMember(d => d.ExpensepaymentLineCode, opt => opt.MapFrom(s => s.lineCode))
           .ForMember(d => d.ExpensepaymentFirstPlanYearFz223Sum, opt => opt.MapFrom(s => s.firstPlanYearFz223Sum))
           .ForMember(d => d.ExpensepaymentFirstPlanYearFz44Sum, opt => opt.MapFrom(s => s.firstPlanYearFz44Sum))
           .ForMember(d => d.ExpensepaymentFirstPlanYearTotalSum, opt => opt.MapFrom(s => s.firstPlanYearTotalSum))
           .ForMember(d => d.ExpensepaymentNextYearFz223Sum, opt => opt.MapFrom(s => s.nextYearFz223Sum))
           .ForMember(d => d.ExpensepaymentNextYearFz44Sum, opt => opt.MapFrom(s => s.nextYearFz44Sum))
           .ForMember(d => d.ExpensepaymentNextYearTotalSum, opt => opt.MapFrom(s => s.nextYearTotalSum))
           .ForMember(d => d.ExpensepaymentSecondPlanYearFz223Sum, opt => opt.MapFrom(s => s.secondPlanYearFz223Sum))
           .ForMember(d => d.ExpensepaymentSecondPlanYearFz44Sum, opt => opt.MapFrom(s => s.secondPlanYearFz44Sum))
           .ForMember(d => d.ExpensepaymentSecondPlanYearTotalSum, opt => opt.MapFrom(s => s.secondPlanYearTotalSum));

        CreateMap<Temporaryresourceslist, FapData>()
            .ForMember(d => d.TemporaryresourceTotal, opt => opt.MapFrom(s => s.total))
            .ForMember(d => d.TemporaryresourceName, opt => opt.MapFrom(s => s.name))
            .ForMember(d => d.TemporaryresourceLineCode, opt => opt.MapFrom(s => s.lineCode));

        CreateMap<Referencelist, FapData>()
            .ForMember(d => d.ReferenceTotal, opt => opt.MapFrom(s => s.total))
            .ForMember(d => d.ReferenceName, opt => opt.MapFrom(s => s.name))
            .ForMember(d => d.ReferenceLineCode, opt => opt.MapFrom(s => s.lineCode));

        CreateMap<Attachment, FapData>()
            .ForMember(d => d.AttachmentFileName, opt => opt.MapFrom(s => s.fileName))
            .ForMember(d => d.AttachmentFileSize, opt => opt.MapFrom(s => s.fileSize))
            .ForMember(d => d.AttachmentDocumentDate, opt => opt.MapFrom(s => s.documentDate))
            .ForMember(d => d.AttachmentPublishDate, opt => opt.MapFrom(s => s.publishDate))
            .ForMember(d => d.AttachmentUrl, opt => opt.MapFrom(s => s.url));
    }
}

