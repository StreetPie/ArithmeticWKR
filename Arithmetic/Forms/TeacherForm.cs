using System;
using System.Windows.Forms;
using Arithmetic.Models;

namespace Arithmetic.Forms
{
    public partial class TeacherForm : Form
    {
        private readonly User _user;

        public TeacherForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = $"Добро пожаловать, учитель {_user.FirstName}!";
        }
    }
}
