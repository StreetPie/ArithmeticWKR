using System;
using System.Windows.Forms;
using Arithmetic.Models;

namespace Arithmetic.Forms
{
    public partial class AdminForm : Form
    {
        private readonly User _user;

        public AdminForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = $"Добро пожаловать, администратор {_user.FirstName}!";
        }
    }
}
