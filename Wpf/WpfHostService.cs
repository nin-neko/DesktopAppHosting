using System.Windows;
using Microsoft.Extensions.Hosting;

namespace Wpf;

class WpfHostService : IHostedService
{
    readonly IHostApplicationLifetime _hostApplicationLifetime;
    readonly Application _app;
    readonly Window _window;

    public WpfHostService(IHostApplicationLifetime hostApplicationLifetime, Application app, Window window)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _app = app;
        _window = window;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _app.Run(_window);

        _hostApplicationLifetime.StopApplication();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
