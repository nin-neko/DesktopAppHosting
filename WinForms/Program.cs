using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinForms;

static class Program
{
    [STAThread]
    static void Main(string[] args)
        => Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddHostedService<WinFormsHostService>();
            services.AddTransient<Form, Form1>();
            services.AddTransient<Lazy<Form>>(c => new(() => c.GetService<Form>()!));
        })
        .Build()
        .Run();
}
