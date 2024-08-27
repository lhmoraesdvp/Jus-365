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
        try
        {
            await ApplicationDbInitializer.InitializeAsync(_serviceProvider);


        }
        catch (Exception ex) {

            Console.WriteLine($"@@@@@@@@@@@@@@@s@@@@@@@@@@@@Exception during initialization: {ex.Message}");
            throw; // Re-throw the exception to be handled by the framework or further debugging
        }


    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
