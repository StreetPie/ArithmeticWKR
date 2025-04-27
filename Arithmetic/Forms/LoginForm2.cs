using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Forms;
using Arithmetic.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic
{
    public partial class LoginForm2 : Form
    {
        private readonly AppDbContext _context;

        public LoginForm2(AppDbContext context)
        {
            AutoScaleMode = AutoScaleMode.Dpi;
            _context = context;
            InitializeComponent();
        }

        private void LoginForm2_Load(object sender, EventArgs e)
        {
            // Автозапуск формы в полноэкранном режиме
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;


            // Загрузка классов и фильтрация
            var classes = _context.Classes.OrderBy(c => c.Name).ToList();
            comboBoxClass.DisplayMember = "Name";
            comboBoxClass.ValueMember = "Id";
            comboBoxClass.DataSource = classes;

            // Загрузка учеников
            LoadStudents();

            radioButtonStudent.Checked = true;

            // Настройка адаптивности для comboBox и других элементов
            comboBoxClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxStudent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonStudent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonTeacher.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxClass.Enabled = true;
            comboBoxStudent.Enabled = true;

        }

        private void LoadStudents(int? classId = null)
        {
            var students = _context.Users
                .Where(u => u.RoleId == 1 && (classId == null || u.ClassId == classId))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            // Скомбинированное имя и фамилия
            comboBoxStudent.DataSource = students;
            comboBoxStudent.DisplayMember = "FullName";  // Это будет автоматически комбинированное "FirstName LastName"
            comboBoxStudent.ValueMember = "Id";  // Используем Id как ValueMember
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При выборе класса, загружаем учеников этого класса
            var classId = (int)comboBoxClass.SelectedValue;
            LoadStudents(classId);
        }

        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            // Включаем/выключаем comboBoxClass и comboBoxStudent для учителей/админов
            if (radioButtonStudent.Checked)
            {
                comboBoxClass.Enabled = true;
                comboBoxStudent.Enabled = true;
            }
            else
            {
                comboBoxClass.Enabled = false;
                comboBoxStudent.Enabled = true;
            }
        }

        private void radioButtonTeacher_CheckedChanged(object sender, EventArgs e)
        {
            // При выборе роли учитель/админ скрываем comboBoxClass
            comboBoxClass.Enabled = false;
            comboBoxStudent.Enabled = true;
            LoadStudents();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var fullName = comboBoxStudent.Text.Trim();
            var password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            var names = fullName.Split(' '); // Разделяем по пробелу
            if (names.Length < 2 && !radioButtonAdmin.Checked)
            {
                MessageBox.Show("Введите имя и фамилию через пробел.");
                return;
            }

            var firstName = names[0];
            var lastName = names[1];

            var passwordHash = HashPassword(password);

            User user = null;
            if (radioButtonStudent.Checked)
            {
                // Для учеников
                user = _context.Users
                    .FirstOrDefault(u => u.FirstName == firstName &&
                                         u.LastName == lastName &&
                                         u.PasswordHash == passwordHash &&
                                         u.RoleId == 1);
            }
            else if (radioButtonTeacher.Checked)
            {
                // Для учителей
                user = _context.Users
                    .FirstOrDefault(u => u.FirstName == firstName &&
                                         u.LastName == lastName &&
                                         u.PasswordHash == passwordHash &&
                                         u.RoleId == 2);
            }
            else if (radioButtonAdmin.Checked)
            {
                // Для админов
                user = _context.Users
                    .FirstOrDefault(u => u.FirstName == firstName &&
                                         u.LastName == lastName &&
                                         u.PasswordHash == passwordHash &&
                                         u.RoleId == 3);
            }

            if (user == null)
            {
                MessageBox.Show("Неверные имя, фамилия, логин или пароль.");
                return;
            }

            MessageBox.Show($"Добро пожаловать, {user.FirstName}!");

            if (user.RoleId == 1)
            {
                var mainForm = new MainForm(user);
                mainForm.Show();
            }
            else if (user.RoleId == 2)
            {
                var teacherForm = new TeacherForm(user);
                teacherForm.Show();
            }
            else if (user.RoleId == 3)
            {
                var adminForm = new AdminForm(user);
                adminForm.Show();
            }

            this.Hide();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
