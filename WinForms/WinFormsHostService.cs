using Microsoft.Extensions.Hosting;

namespace WinForms;

class WinFormsHostService : IHostedService
{
    readonly IHostApplicationLifetime _hostApplicationLifetime;
    readonly Lazy<Form> _formFactory;

    public WinFormsHostService(IHostApplicationLifetime hostApplicationLifetime, Lazy<Form> formFactory)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _formFactory = formFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(_formFactory.Value);

        _hostApplicationLifetime.StopApplication();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
