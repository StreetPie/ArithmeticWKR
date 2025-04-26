using System;
using System.Linq;
using System.Windows.Forms;
using Arithmetic.Database;

namespace Arithmetic.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly AppDbContext _dbContext;

        public RegistrationForm(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadClasses();
        }

        private void LoadClasses()
        {
            var classes = _dbContext.Classes.OrderBy(c => c.Name).ToList();
            comboBoxClass.DataSource = classes;
            comboBoxClass.DisplayMember = "Name";
            comboBoxClass.ValueMember = "Id";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (_dbContext.Users.Any(u => u.Login == textBoxLogin.Text))
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }

            var newUser = new Arithmetic.Models.User
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                DateOfBirth = dateTimePickerDOB.Value,
                ClassId = (int)comboBoxClass.SelectedValue,
                RoleId = 1 // Ученик
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно");
            Close();
        }
    }
}
