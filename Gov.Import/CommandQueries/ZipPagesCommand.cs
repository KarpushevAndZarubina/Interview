using System.IO.Compression;
using System.Text.Json.Nodes;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Gov.Import.CommandQueries;
public record ZipPagesCommand(DateTime From, DateTime To) : IRequest<string>;
internal class ZipPagesCommandHandler : IRequestHandler<ZipPagesCommand, string>
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly ILogger<ZipPagesCommand> logger;

    public ZipPagesCommandHandler(IMediator mediator, IMapper mapper, ILogger<ZipPagesCommand> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<string> Handle(ZipPagesCommand command, CancellationToken cancellationToken)
    {
        var path = $"{command.From:ddMMyyyy}_{command.To:ddMMyyyy}";
        logger.LogInformation("загрузка периода {0}", path);
        Directory.CreateDirectory($"Data/{path}");

        var totalPages = 100;
        for (int p = 0; p < totalPages; p++)
        {
            var content = string.Empty;

            try
            {
                logger.LogInformation("запрос страницы {0}", p);

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 YaBrowser/23.5.4.674 Yowser/2.5 Safari/537.36");
                var response = await httpClient.GetAsync($"https://bus.gov.ru/public-rest/api/epbs/fap?LastUpdateFrom={command.From:dd.MM.yyyy}&lastUpdateTo={command.To:dd.MM.yyyy}&page={p}&size=100");
                content = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                totalPages = JsonNode.Parse(content)["totalPages"].GetValue<int>();
                File.WriteAllText(Path.Combine($"Data/{path}", $"{p}.json"), content);
                await Task.Delay(TimeSpan.FromSeconds(2)); //иначе сайт считает запросы спамом и зависает
            }
            catch (Exception ex) { logger.LogError(ex, "page:{0}\n{1}", p, content); }
        }

        if (File.Exists($"Data/{path}.zip")) File.Delete($"Data/{path}.zip");
        ZipFile.CreateFromDirectory($"Data/{path}", $"Data/{path}.zip");
        Directory.Delete($"Data/{path}", true);

        logger.LogInformation("упаковка завершена");

        return $"Data/{path}.zip";
    }
}
