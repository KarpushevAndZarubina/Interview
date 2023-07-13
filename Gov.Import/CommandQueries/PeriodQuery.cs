using MediatR;

using Microsoft.Extensions.Logging;

namespace Gov.Import.CommandQueries;
public record PeriodQuery() : IRequest<(DateTime From, DateTime To)>;
internal class PeriodQueryHandler : IRequestHandler<PeriodQuery, (DateTime From, DateTime To)>
{
    private readonly IMediator mediator;
    private readonly ILogger<PeriodQueryHandler> logger;

    public PeriodQueryHandler(IMediator mediator, ILogger<PeriodQueryHandler> logger)
    {
        this.mediator = mediator;
        this.logger = logger;
    }

    public Task<(DateTime From, DateTime To)> Handle(PeriodQuery command, CancellationToken cancellationToken)
    {
        DateTime from, to;

        while (true)
        {
            Console.WriteLine("введите LastUpdateFrom (dd.MM.yyyy):");
            var lastUpdateFrom = Console.ReadLine();
            if (DateTime.TryParse(lastUpdateFrom, out from)) break;
            Console.Clear();
        }

        while (true)
        {
            Console.WriteLine("введите LastUpdateTo (dd.MM.yyyy):");
            var lastUpdateTo = Console.ReadLine();
            if (DateTime.TryParse(lastUpdateTo, out to)) break;
            Console.Clear();
        }

        Console.Clear();
        return Task.FromResult((from, to));
    }
}
