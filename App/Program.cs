using App.Contexts;
using App.Forms;
using App.Repositories;
using App.Services;
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

        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        var form = serviceProvider.GetRequiredService<KassaOverzichtForm>();
        Application.Run(form);
    }

    static void ConfigureServices(ServiceCollection services)
    {
        // Forms
        services.AddScoped<KassaOverzichtForm>();
        services.AddScoped<AfrekenForm>();
        services.AddScoped<BeheerderForm>();
        services.AddScoped<BestellingenSamenvoegenForm>();
        services.AddScoped<BestellingInformatieForm>();
        services.AddScoped<BestellingOverzichtForm>();
        services.AddScoped<CashForm>();
        services.AddScoped<CustomerForm>();
        services.AddScoped<KlantDetailForm>();
        services.AddScoped<OmzetOverzichtForm>();
        services.AddScoped<PinForm>();
        services.AddScoped<ProductDetailForm>();
        services.AddScoped<ProductOverzichtForm>();
        services.AddScoped<SplitBestellingForm>();
        services.AddScoped<TeruggaveForm>();

        // Database
        services.AddScoped<BarkeeperContext>();

        // Repositories
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IRevenueRepository, RevenueRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

        // Services
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IMoneyCalculator, MoneyCalculator>();
        services.AddScoped<IRevenueService, RevenueService>();
        services.AddScoped<ISessionService, SessionService>();
    }
}