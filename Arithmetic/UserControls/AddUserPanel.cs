using System;
using System.Linq;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Services;
using Arithmetic.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.UserControls
{
    public partial class AddUserPanel : UserControl
    {
        private readonly IServiceScopeFactory _scopeFactory;

        // Определение события
        public event Action OnUserAdded;

        public AddUserPanel(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            InitializeComponent();
            LoadRoles();
            LoadClasses();
        }

        private void LoadRoles()
        {
            comboRole.Items.Clear();
            comboRole.Items.Add("Ученик");
            comboRole.Items.Add("Учитель");
            comboRole.SelectedIndex = 0;
        }

        private void LoadClasses()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var classes = context.Classes.ToList();
            comboClass.DataSource = classes;
            comboClass.DisplayMember = "Name";
            comboClass.ValueMember = "Id";
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboClass.Enabled = comboRole.SelectedIndex == 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            DateTime dob = datePicker.Value;
            int roleId = comboRole.SelectedIndex == 0 ? 1 : 2;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Имя и фамилия обязательны");
                return;
            }

            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                RegistrationDate = DateTime.Now,
                RoleId = roleId,
                ClassId = roleId == 1 ? (int?)comboClass.SelectedValue : null
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            MessageBox.Show("Пользователь добавлен");

            OnUserAdded?.Invoke();
        }
    }
}
