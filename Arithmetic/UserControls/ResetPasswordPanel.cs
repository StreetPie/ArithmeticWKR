using System;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;

namespace Arithmetic.UserControls
{
    public partial class ResetPasswordPanel : UserControl
    {
        private readonly AppDbContext _context;
        private readonly User _user;

        public ResetPasswordPanel(AppDbContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;

            labelUser.Text = $"Пользователь: {_user.LastName} {_user.FirstName}";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string newPassword = textBoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Введите новый пароль.");
                return;
            }

            _user.PasswordHash = newPassword; // Здесь лучше будет захешировать!
            _context.Users.Update(_user);
            _context.SaveChanges();

            MessageBox.Show("Пароль сброшен.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
