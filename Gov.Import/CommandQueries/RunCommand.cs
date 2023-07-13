using System.Reflection;

using AutoMapper;

using Gov.ApiClient;
using Gov.ApiClient.Model;
using Gov.Import.Data;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Gov.Import.CommandQueries;
public record RunCommand() : IRequest;
internal class ConvertCommandHandler : IRequestHandler<RunCommand>
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly ILogger<ConvertCommandHandler> logger;

    public ConvertCommandHandler(IMediator mediator, IMapper mapper, ILogger<ConvertCommandHandler> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task Handle(RunCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Версия сборки v.{Assembly.GetExecutingAssembly().GetName().Version}");

        var dates = await mediator.Send(new PeriodQuery());
        var zipPath = await mediator.Send(new ZipPagesCommand(dates.From, dates.To));
        await mediator.Send(new ZipImportCommand(zipPath, dates.From, dates.To));
    }
}
