using Gov.Import.Extension;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices(s => s.AddAppServices());
var host = builder.Build();
host.Run();
