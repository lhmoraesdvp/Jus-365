using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

public class ApplicationStartupService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationStartupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
       await ApplicationDbInitializer.InitializeAsync(_serviceProvider);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
