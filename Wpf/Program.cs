using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Wpf;

static class Program
{
    [STAThread]
    static void Main(string[] args)
        => Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddHostedService<WpfHostService>();
            services.AddSingleton<Application, App>();
            services.AddTransient<Window, MainWindow>();
        })
        .Build()
        .Run();
}
