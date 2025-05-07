using System;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Interfaces;
using Arithmetic.Models;
using Arithmetic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.Forms
{
    public partial class MainForm : Form
    {
        private readonly UserSessionService _sessionService;
        private readonly IFormFactory<IndependentWorkForm> _independentWorkFactory;

        private User CurrentUser => _sessionService.CurrentUser;

        public MainForm(UserSessionService sessionService, IFormFactory<IndependentWorkForm> independentWorkFactory)
        {
            _independentWorkFactory = independentWorkFactory;

            _sessionService = sessionService;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;

            LoadUserInfo();
            BlurService.EnableBlur(this);
            this.PerformLayout();
        }


        private void LoadUserData()
        {
            using (var scope = Program.AppHost.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                _sessionService.LoadProgress(context);
                UpdateUI();
            }
        }
        private void UpdateUI()
        {
            // обновить бы интерфейс 
        }
        private void LoadUserInfo()
        {
            labelName.Text = $"Имя: {CurrentUser.FirstName}";
            labelSurname.Text = $"Фамилия: {CurrentUser.LastName}";
            labelClass.Text = $"Класс: {CurrentUser.Class?.Name ?? "Не указан"}";
        }

        private void buttonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonHoverColor;
        }

        private void buttonBack_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonColor;
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            using (var confirmationForm = new ExitConfirmationForm("Вы точно хотите выйти из профиля?"))
            {
                confirmationForm.ShowDialog();

                if (confirmationForm.Confirmed)
                {
                    var loginForm = Program.AppHost.Services.GetRequiredService<LoginForm>();
                    loginForm.Show();
                    this.Close();
                }
            }
        }

    }
}