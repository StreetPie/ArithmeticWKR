using System;
using System.Linq;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;

namespace Arithmetic.UserControls
{
    public partial class AddUserPanel : UserControl
    {
        private readonly AppDbContext _context;

        public event Action OnUserAdded;

        public AddUserPanel(AppDbContext context)
        {
            _context = context;

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
            var classes = _context.Classes.ToList();
            comboClass.DataSource = classes;
            comboClass.DisplayMember = "Name";
            comboClass.ValueMember = "Id";
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboClass.Enabled = comboRole.SelectedIndex == 0; // Только для учеников
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

            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                RegistrationDate = DateTime.Now,
                RoleId = roleId,
                ClassId = roleId == 1 ? (int?)comboClass.SelectedValue : null
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            MessageBox.Show("Пользователь добавлен");
            OnUserAdded?.Invoke();
        }
    }
}
