using Arithmetic.Forms;
using System;
using System.Windows.Forms;
using Arithmetic.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Полноэкранный режим
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using (var scope = Program.AppHost.Services.CreateScope())
            {
                var loginForm2 = scope.ServiceProvider.GetRequiredService<LoginForm2>();
                this.Hide();
                loginForm2.ShowDialog();
                this.Show();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            using (var scope = Program.AppHost.Services.CreateScope())
            {
                var registrationForm = scope.ServiceProvider.GetRequiredService<RegistrationForm>();
                this.Hide();
                registrationForm.ShowDialog();
                this.Show();
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
