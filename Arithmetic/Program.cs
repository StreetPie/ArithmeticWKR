using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Arithmetic.Forms;
using Arithmetic.Services;
using Arithmetic.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Arithmetic;

internal static class Program
{



    public static IHost AppHost; 

    [STAThread]
    static void Main(string[] args)
    {


        AppHost = CreateHostBuilder(args).Build();

        ApplicationConfiguration.Initialize();

        using (var scope = AppHost.Services.CreateScope()) 
        {

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            try
            {
                if (!context.Database.CanConnect())
                {
                    MessageBox.Show($"Ошибка подключения к базе данных: не удалось установить соединение.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
                return;
            }
        }

        ApplicationConfiguration.Initialize();

        //  var loginForm = AppHost.Services.GetRequiredService<LoginForm>(); 
        //Application.Run(loginForm);
        var teacherForm = AppHost.Services.GetRequiredService<TeacherForm>();
        Application.Run(teacherForm);
        
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args) 
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("LocalConnection");

                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddScoped<LoginForm>();
                services.AddScoped<LoginForm2>();
                services.AddScoped<RegistrationForm>();
                services.AddScoped<MainForm>();
                services.AddScoped<TeacherForm>();
                services.AddScoped<AdminForm>();
                //services.AddScoped<Бассейн_п_о>();
                services.AddScoped<TaskConstructorForm>();
                services.AddScoped<ProgressChartForm>();
                services.AddScoped<StudentsListForm>();
                services.AddScoped<TestConstructorForm>();
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
                //services.AddScoped
            });

}
