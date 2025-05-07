using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Arithmetic.Forms;
using Arithmetic.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Arithmetic.UserControls;
using Arithmetic.Interfaces;
using Arithmetic.DependencyInjection;
using Arithmetic.Services;


namespace Arithmetic;

internal static class Program
{
    public static IHost AppHost;

    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        string connectionString = GetWorkingConnectionString();

        if (string.IsNullOrEmpty(connectionString))
        {
            MessageBox.Show("Не удалось подключиться ни к локальной, ни к удалённой базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        AppHost = CreateHostBuilder(args, connectionString).Build();

        using (var scope = AppHost.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();

            try
            {
                if (!context.Database.CanConnect())
                {
                    MessageBox.Show($"Ошибка подключения к базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        var loginForm = AppHost.Services.GetRequiredService<LoginForm>();
        Application.Run(loginForm);
    }

    static IHostBuilder CreateHostBuilder(string[] args, string connectionString) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.RegisterFormsAndPanels(); //ну капец блин ну жесть сколько с этим париться :(

                services.AddSingleton<UserSessionService>();
                services.AddSingleton<BlurService>();

            });

    private static string GetWorkingConnectionString()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var localConnection = config.GetConnectionString("LocalConnection");
        var remoteConnection = config.GetConnectionString("RemoteConnection");

        if (TestConnection(localConnection))
        {
            return localConnection;
        }

        if (TestConnection(remoteConnection))
        {
            return remoteConnection;
        }

        return null;
    }

    private static bool TestConnection(string connectionString)
    {
        try
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                return context.Database.CanConnect();
            }
        }
        catch
        {
            return false;
        }
    }
}
