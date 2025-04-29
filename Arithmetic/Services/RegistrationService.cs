using Arithmetic.Forms;
using Arithmetic.Interfaces;
using Arithmetic.Services;
using Arithmetic.UserControls;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.DependencyInjection
{
    public static class RegistrationService
    {
        public static void RegisterFormsAndPanels(this IServiceCollection services)
        {
            // Фабрика
            services.AddTransient(typeof(IFormFactory<>), typeof(FormFactory<>));

           //сервисы
            services.AddSingleton<UserSessionService>();

            // Формы
            services.AddTransient<MainForm>();
            services.AddTransient<TeacherForm>();
            services.AddTransient<AdminForm>();
            services.AddTransient<LoginForm2>();
            services.AddTransient<RegistrationForm>();

            // Панели
            services.AddTransient<AddUserPanel>();
            services.AddTransient<AssignTeacherClassesPanel>();
            services.AddTransient<CreateClassPanel>();
            services.AddTransient<EditUserPanel>();
            services.AddTransient<MoveStudentPanel>();
            services.AddTransient<ResetPasswordPanel>();
        }
    }
}
