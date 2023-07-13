using Microsoft.Extensions.DependencyInjection;
using Gov.Import.Extension;
using MediatR;
using Gov.Import.CommandQueries;

namespace Gov.Tests;


[TestClass]
public class CommandTest
{
    IServiceProvider sp;

    public CommandTest()
    {
        var services = new ServiceCollection();
        services.AddAppServices();
        sp = services.BuildServiceProvider();
    }

    [TestMethod]
    public async Task ZipImport()
    {
        var mediator = sp.GetService<IMediator>();
        await mediator.Send(new ZipImportCommand("04122019_10122019.zip", new DateTime(2019, 12, 4), new DateTime(2019, 12, 10)));
    }
}