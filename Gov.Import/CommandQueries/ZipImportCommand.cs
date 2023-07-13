using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using AutoMapper;

using Gov.ApiClient.Model;
using Gov.Import.Data;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Gov.Import.CommandQueries;
public record ZipImportCommand(string Path, DateTime From, DateTime To) : IRequest;
internal class ZipImportCommandHandler : IRequestHandler<ZipImportCommand>
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly IRepository<FapData> rpFap;
    private readonly ILogger<ZipImportCommandHandler> logger;

    public ZipImportCommandHandler(IMediator mediator, IMapper mapper, IRepository<FapData> rpFap, ILogger<ZipImportCommandHandler> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.rpFap = rpFap;
        this.logger = logger;
    }

    public async Task Handle(ZipImportCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("импорт данных в БД...");

        var fapDataList = new List<FapData>();
        var zip = ZipFile.OpenRead(command.Path);
        foreach (var entry in zip.Entries)
        {
            using var ms = new MemoryStream();
            entry.Open().CopyTo(ms);
            var buffer = ms.ToArray();
            var json = Encoding.UTF8.GetString(buffer);
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Converters.Add(new JsonDateTimeConverter());
            var fapResonse = JsonSerializer.Deserialize<FapResponse>(json, jsonOptions);

            var commonPropList = typeof(Common).GetProperties();
            var IndicatorsoffinancialconditionPropList = typeof(Indicatorsoffinancialcondition).GetProperties();

            var fapDataType = typeof(FapData);

            foreach (var content in fapResonse.content)
            {
                var attachmentList = mapper.Map<List<FapData>>(content.attachments);
                var referenceList = mapper.Map<List<FapData>>(content.referenceList);
                var resourceList = mapper.Map<List<FapData>>(content.temporaryResourcesList);
                var expensePaymentList = mapper.Map<List<FapData>>(content.expensePaymentIndexes);
                var planPaymentMainList = mapper.Map<List<FapData>>(content.planPaymentIndexesMain);
                var planPaymentList = mapper.Map<List<FapData>>(content.planPaymentIndexes);

                //var fapContentDataList = new List<FapData>(attachmentList.Count * referenceList.Count * resourceList.Count * expensePaymentList.Count * planPaymentMainList.Count * planPaymentList.Count);
                var fapContentDataList = new List<FapData>();
                fapContentDataList.AddRange(attachmentList);
                fapContentDataList.AddRange(referenceList);
                fapContentDataList.AddRange(resourceList);
                fapContentDataList.AddRange(expensePaymentList);
                fapContentDataList.AddRange(planPaymentMainList);
                fapContentDataList.AddRange(planPaymentList);

                foreach (var fapData in fapContentDataList)
                {
                    foreach (var prop in commonPropList) fapDataType.GetProperty(prop.Name).SetValue(fapData, prop.GetValue(content.common));
                    foreach (var prop in IndicatorsoffinancialconditionPropList) fapDataType.GetProperty(prop.Name).SetValue(fapData, prop.GetValue(content.indicatorsOfFinancialCondition));
                }

                fapDataList.AddRange(fapContentDataList);
            }

        }

        var existList = rpFap.List(i => i.lastUpdate >= command.From && i.lastUpdate <= command.To);
        if (existList.Count > 0) await rpFap.DeleteAsync(existList);
        await rpFap.InsertAsync(fapDataList);

        logger.LogInformation("импорт завершен.");

    }
}


internal class JsonDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("dd.MM.yyyy"));
    }
}
