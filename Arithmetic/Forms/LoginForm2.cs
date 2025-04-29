using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Forms;
using Arithmetic.Interfaces;
using Arithmetic.Models;
using Arithmetic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic
{
    public partial class LoginForm2 : Form
    {
        private readonly AppDbContext _context;
        private System.Windows.Forms.Timer fadeInTimer;

        public LoginForm2(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            EnableBlur();
            this.BringToFront();
        }

        private void InitializeFadeIn() //пока не используем, но оставляем
        {
            this.Opacity = 0;
            fadeInTimer = new System.Windows.Forms.Timer();
            fadeInTimer.Interval = 30;
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fadeInTimer.Stop();
            };
            fadeInTimer.Start();
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private void LoginForm2_Load(object sender, EventArgs e)
        {
            var classes = _context.Classes.OrderBy(c => c.Name).ToList();
            comboBoxClass.DisplayMember = "Name";
            comboBoxClass.ValueMember = "Id";
            comboBoxClass.DataSource = classes;

            LoadStudents();
            radioButtonStudent.Checked = true;

            comboBoxClass.Enabled = true;
            comboBoxStudent.Enabled = true;
        }


        private void LoadStudents(int? classId = null, int roleId = 1)
        {
            IQueryable<User> query = _context.Users.Where(u => u.RoleId == roleId);

            if (roleId == 1) // Ученик
            {
                if (classId.HasValue)
                {
                    query = query.Where(u => u.ClassId == classId.Value);
                }
                query = query.Where(u => u.FirstName != null && u.LastName != null);
                query = query.OrderBy(u => u.LastName).ThenBy(u => u.FirstName);
            }
            else if (roleId == 2) // Учитель
            {
                query = query.Where(u => u.FirstName != null && u.LastName != null);
                query = query.OrderBy(u => u.LastName).ThenBy(u => u.FirstName);
            }
            else if (roleId == 3) // Админ
            {
                query = query.Where(u => u.FirstName != null); // Только имя
                query = query.OrderBy(u => u.FirstName);
            }

            var students = query
                .Select(u => new
                {
                    u.Id,
                    FullName = (u.FirstName ?? "") + (u.LastName != null ? " " + u.LastName : "")
                })
                .ToList();

            comboBoxStudent.DataSource = students;
            comboBoxStudent.DisplayMember = "FullName";
            comboBoxStudent.ValueMember = "Id";
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();

        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonStudent.Checked)
            {
                int classId = (int)comboBoxClass.SelectedValue;
                LoadStudents(classId, roleId: 1);
            }
        }

        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            comboBoxClass.Visible = true;
            labelClass.Visible = true;
            LoadStudents(roleId: 1);
        }

        private void radioButtonTeacher_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            comboBoxClass.Visible = false;
            labelClass.Visible = false;
            LoadStudents(roleId: 2);
        }
        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            comboBoxClass.Visible = false;
            labelClass.Visible = false;
            LoadStudents(roleId: 3);
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var fullName = comboBoxStudent.Text.Trim();
            var password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var names = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = names[0];
            string lastName = names.Length > 1 ? names[1] : null;

            var passwordHash = HashPassword(password);

            User user = null;

            if (radioButtonStudent.Checked)
            {
                if (names.Length < 2)
                {
                    MessageBox.Show("Введите имя и фамилию через пробел.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxClass.SelectedItem == null)
                {
                    MessageBox.Show("Выберите класс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int classId = (int)comboBoxClass.SelectedValue;

                user = _context.Users.FirstOrDefault(u =>
                    u.FirstName == firstName &&
                    u.LastName == lastName &&
                    u.PasswordHash == passwordHash &&
                    u.ClassId == classId &&
                    u.RoleId == 1);
            }
            else if (radioButtonTeacher.Checked)
            {
                if (names.Length < 2)
                {
                    MessageBox.Show("Введите имя и фамилию через пробел.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                user = _context.Users.FirstOrDefault(u =>
                    u.FirstName == firstName &&
                    u.LastName == lastName &&
                    u.PasswordHash == passwordHash &&
                    u.RoleId == 2);
            }
            else if (radioButtonAdmin.Checked)
            {
                user = _context.Users.FirstOrDefault(u =>
                    u.FirstName == firstName &&
                    u.PasswordHash == passwordHash &&
                    u.RoleId == 3);
            }

            if (user == null)
            {
                MessageBox.Show("Неверные имя, фамилия, пароль или класс.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Добро пожаловать, {user.FirstName}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();

            using (var scope = Program.AppHost.Services.CreateScope())
            {
                if (user.RoleId == 1)
                {
                    var session = scope.ServiceProvider.GetRequiredService<UserSessionService>();
                    session.SetUser(user);
                    var mainForm = scope.ServiceProvider
                        .GetRequiredService<IFormFactory<MainForm>>()
                        .Create(user);
                    mainForm.Show();
                    this.Hide();
                }
                else if (user.RoleId == 2)
                {
                    var teacherForm = scope.ServiceProvider
                        .GetRequiredService<IFormFactory<TeacherForm>>()
                        .Create(user);
                    teacherForm.Show();
                    this.Hide();
                }
                else if (user.RoleId == 3)
                {
                    var adminForm = scope.ServiceProvider
                        .GetRequiredService<IFormFactory<AdminForm>>()
                        .Create(user);
                    adminForm.Show();
                    this.Hide();
                }
            }


        }


        private void EnableBlur()
        {
            var accent = new AccentPolicy();
            accent.AccentState = 3;

            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = 19;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(this.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public int AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public int Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void LoginForm2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.A)
            {
                radioButtonAdmin.Visible = true;
            }
        }
        private void ButtonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonLogin.BackColor = BlueButtonHoverColor;
        }

        private void ButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackColor = BlueButtonColor;
        }

        private void ButtonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonHoverColor;
        }

        private void ButtonBack_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonColor;
        }

    }
}
