using System;
using System.Windows.Forms;
using Arithmetic.Interfaces;
using Arithmetic.Models;
using Arithmetic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.Forms
{
    public partial class IndependentWorkForm : Form
    {
        private readonly IFormFactory<IndependentWorkForm> _independentWorkFactory;

        private readonly UserSessionService _sessionService;
        private User CurrentUser => _sessionService.CurrentUser;

        public IndependentWorkForm(UserSessionService sessionService, IFormFactory<IndependentWorkForm> independentWorkFactory)
        
           
        {

            _independentWorkFactory = independentWorkFactory;
            _sessionService = sessionService;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;

            BlurService.EnableBlur(this);
            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            labelName.Text = $"Имя: {CurrentUser.FirstName}";
            labelSurname.Text = $"Фамилия: {CurrentUser.LastName}";
            labelClass.Text = $"Класс: {CurrentUser.Class?.Name ?? "Не указан"}";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var factory = Program.AppHost.Services.GetRequiredService<IFormFactory<MainForm>>();
            var form = factory.Create();
            form.Show();
            this.Close();

        }

        private void buttonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonHoverColor;
        }

        private void buttonBack_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonColor;
        }
    }
}
