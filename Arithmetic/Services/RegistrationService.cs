using Arithmetic.Forms;
using Arithmetic.Interfaces;
using Arithmetic.Services;
using Arithmetic.UserControls;
using Microsoft.Extensions.DependencyInjection;
using static Arithmetic.Forms.ClassWorkForm;

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
            services.AddSingleton<BlurService>();

            services.AddScoped<IChapterService, ChapterService>();
            services.AddScoped<IParagraphService, ParagraphService>();
            services.AddScoped<ICompletionService, CompletionService>();

            // Формы
            services.AddTransient<LoginForm2>();
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<TeacherForm>();
            services.AddTransient<AdminForm>();
            services.AddTransient<RegistrationForm>();
            services.AddTransient<StudentsListForm>();
            services.AddTransient<StudentProfileForm>();
            services.AddTransient<IndependentWorkForm>();
            services.AddTransient<ClassWorkForm>();


            //Панели
            services.AddScoped<IFormFactory<AddUserPanel>, FormFactory<AddUserPanel>>();
            services.AddScoped<IFormFactory<AssignTeacherClassesPanel>,FormFactory<AssignTeacherClassesPanel>>();
            services.AddScoped<IFormFactory<CreateClassPanel>, FormFactory<CreateClassPanel>>();
            services.AddScoped<IFormFactory<EditUserPanel>, FormFactory<EditUserPanel>>();
            services.AddScoped<IFormFactory<MoveStudentPanel>, FormFactory<MoveStudentPanel>>();
            services.AddScoped<IFormFactory<ResetPasswordPanel>, FormFactory<ResetPasswordPanel>>();
        }
    }
}
