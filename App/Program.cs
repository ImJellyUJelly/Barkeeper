using App.Agents;
using App.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace App;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var services = new ServiceCollection();
        ConfigureServices(services);

        using (ServiceProvider serviceProvider = services.BuildServiceProvider())
        {
            var form = serviceProvider.GetRequiredService<OrderOverviewForm>();

            Application.Run(form);
        }
    }

    static void ConfigureServices(ServiceCollection services)
    {
        // Forms
        services.AddScoped<OrderOverviewForm>();

        // Agents
        services.AddScoped<IOrderAgent, OrderAgent>();
        
        // Services
    }
}
