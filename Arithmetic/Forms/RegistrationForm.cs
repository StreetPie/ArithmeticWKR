using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;

namespace Arithmetic
{
    public partial class RegistrationForm : Form
    {
        private readonly AppDbContext _context;

        public RegistrationForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            var classes = _context.Classes.OrderBy(c => c.Name).ToList();
            comboBoxClass.DataSource = classes;
            comboBoxClass.DisplayMember = "Name";
            comboBoxClass.ValueMember = "Id";
            comboBoxClass.SelectedIndex = -1;

            comboBoxClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonRegister.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var firstName = textBoxFirstName.Text.Trim();
            var lastName = textBoxLastName.Text.Trim();
            var password = textBoxPassword.Text.Trim();
            var dateOfBirth = dateTimePickerDOB.Value;
            var classId = (int?)comboBoxClass.SelectedValue;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все обязательные поля.");
                return;
            }

            if (!classId.HasValue)
            {
                MessageBox.Show("Выберите класс.");
                return;
            }

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                PasswordHash = HashPassword(password),
                DateOfBirth = dateOfBirth,
                RegistrationDate = DateTime.Now,
                RoleId = 1, // Ученик
                ClassId = classId
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно.");
            this.Close();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
