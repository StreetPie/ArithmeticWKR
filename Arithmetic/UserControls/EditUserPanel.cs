using System;
using System.Drawing;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;
using Arithmetic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.UserControls
{
    public partial class EditUserPanel : UserControl
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private User _user;
        private readonly int _userId;

        public event EventHandler UserUpdated;

        public EditUserPanel(UserSessionService session, IServiceScopeFactory scopeFactory, int userId)
        {
            InitializeComponent();  // Инициализация компонентов
            _scopeFactory = scopeFactory;
            _userId = userId;

            LoadData();
        }

        private void LoadData()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            _user = context.Users.FirstOrDefault(u => u.Id == _userId);
            if (_user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            txtFirstName.Text = _user.FirstName;
            txtLastName.Text = _user.LastName;
            datePicker.Value = _user.DateOfBirth;

            if (_user.RoleId == 1)
            {
                comboClass.DataSource = context.Classes.ToList();
                comboClass.DisplayMember = "Name";
                comboClass.ValueMember = "Id";
                comboClass.SelectedValue = _user.ClassId;
                comboClass.Visible = true;
                labelClass.Visible = true;
            }
            else
            {
                comboClass.Visible = false;
                labelClass.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var user = context.Users.FirstOrDefault(u => u.Id == _userId);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.DateOfBirth = datePicker.Value;

            if (user.RoleId == 1 && comboClass.SelectedItem is Class selectedClass)
            {
                user.ClassId = selectedClass.Id;
            }

            context.Users.Update(user);
            context.SaveChanges();

            MessageBox.Show("Изменения сохранены.");
            UserUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
