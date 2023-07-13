using Gov.Import.CommandQueries;

using MediatR;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gov.Import.Services;
public class HostingService : BackgroundService
{
    private readonly IMediator mediator;
    private readonly ILogger<HostingService> logger;

    public HostingService(IMediator mediator, ILogger<HostingService> logger)
    {
        this.mediator = mediator;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await mediator.Send(new RunCommand(), stoppingToken);
    }
}
