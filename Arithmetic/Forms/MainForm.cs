using System;
using System.Windows.Forms;
using Arithmetic.Models;

namespace Arithmetic.Forms
{
    public partial class MainForm : Form
    {
        private readonly User _user;

        public MainForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = $"Добро пожаловать, {_user.FirstName}!";
        }
    }
}
