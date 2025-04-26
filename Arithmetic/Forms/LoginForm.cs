using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Здесь будет логика входа
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Здесь будет логика регистрации
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
