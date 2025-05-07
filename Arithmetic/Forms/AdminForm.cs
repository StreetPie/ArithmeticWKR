using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Arithmetic.Models;
using Arithmetic.Database;
using Arithmetic.UserControls;
using Arithmetic.Interfaces;
using Arithmetic.Services;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.Forms
{

    public partial class AdminForm : Form
    {
        private readonly IFormFactory<AddUserPanel> _addUserFactory;
        private readonly IFormFactory<AssignTeacherClassesPanel> _assignFactory;
        private readonly IFormFactory<CreateClassPanel> _createClassFactory;
        private readonly IFormFactory<EditUserPanel> _editUserFactory;
        private readonly IFormFactory<MoveStudentPanel> _moveStudentFactory;
        private readonly IFormFactory<ResetPasswordPanel> _resetPasswordFactory;
        private readonly UserSessionService _session;
        private readonly IServiceScopeFactory _scopeFactory;
        private SplitContainer splitContainer;


        private readonly IServiceProvider _provider;
        private IServiceScope _editPanelScope; // добавь это поле в класс AdminForm


        public AdminForm(
            UserSessionService session,
            IServiceScopeFactory scopeFactory,
            IFormFactory<AddUserPanel> addUserFactory,
            IFormFactory<AssignTeacherClassesPanel> assignFactory,
            IFormFactory<CreateClassPanel> createClassFactory,
            IFormFactory<EditUserPanel> editUserFactory,
            IFormFactory<MoveStudentPanel> moveStudentFactory,
            IFormFactory<ResetPasswordPanel> resetPasswordFactory)
        {
            _session = session;
            _scopeFactory = scopeFactory;
            _addUserFactory = addUserFactory;
            _assignFactory = assignFactory;
            _createClassFactory = createClassFactory;
            _editUserFactory = editUserFactory;
            _moveStudentFactory = moveStudentFactory;
            _resetPasswordFactory = resetPasswordFactory;
            InitializeComponent();
            BlurService.EnableBlur(this);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadTeachers();
            LoadStudents();

        }


        private void ShowControl(UserControl control)
        {
            panelRightContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelRightContainer.Controls.Add(control);
            panelRightContainer.Visible = true;
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

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private void LoadTeachers()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var teachers = context.Users
                    .Where(u => u.RoleId == 2)
                    .Select(u => new
                    {
                        u.Id,
                        Имя = u.FirstName,
                        Фамилия = u.LastName,
                        Зарегистрирован = u.RegistrationDate.ToShortDateString()

                    })
                    .ToList();

                if (teachers == null || teachers.Count == 0)
                {
                    MessageBox.Show("Нет данных для отображения учителей.");
                }

                dataGridViewTeachers.DataSource = teachers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных учителей: {ex.Message}");
            }
        }

        private void LoadStudents()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var students = context.Users
                    .Include(u => u.Class)
                    .Where(u => u.RoleId == 1)
                    .Select(u => new
                    {
                        u.Id,
                        Имя = u.FirstName,
                        Фамилия = u.LastName,
                        Класс = u.Class.Name,
                        Дата_рождения = u.DateOfBirth.ToShortDateString(),
                        Зарегистрирован = u.RegistrationDate.ToShortDateString()
                    })
                    .ToList();

                if (students == null || students.Count == 0)
                {
                    MessageBox.Show("Нет данных для отображения студентов.");
                }

                dataGridViewStudents.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных студентов: {ex.Message}");
            }
        }


        private Arithmetic.Models.User GetSelectedUser(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
                return null;

            int userId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);

            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            return context.Users.Include(u => u.Class).FirstOrDefault(u => u.Id == userId);
        }


        private void ButtonAddUser_Click(object sender, EventArgs e)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var panel = _addUserFactory.Create(context);

            panel.OnUserAdded += () =>
            {
                LoadTeachers();
                LoadStudents();
            };
            ShowControl(panel);
        }



        private void ButtonEditUser_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedUser(dataGridViewTeachers) ?? GetSelectedUser(dataGridViewStudents);
            if (selected == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

            _editPanelScope?.Dispose();
            _editPanelScope = _scopeFactory.CreateScope();

            // просто передай user.Id
            var panel = _editUserFactory.Create(selected.Id);
            panel.UserUpdated += (_, __) =>
            {
                LoadTeachers();
                LoadStudents();
            };
            panel.Disposed += (_, __) => _editPanelScope?.Dispose();

            ShowControl(panel);
        }



        private void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser(dataGridViewTeachers) ?? GetSelectedUser(dataGridViewStudents);
            if (user == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var confirm = MessageBox.Show("Удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                LoadTeachers();
                LoadStudents();
            }
        }

        private void ButtonResetPassword_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser(dataGridViewTeachers) ?? GetSelectedUser(dataGridViewStudents);
            if (user == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var panel = _resetPasswordFactory.Create(context, user);
            ShowControl(panel);
        }


        private void ButtonMoveStudent_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser(dataGridViewStudents);
            if (user == null || user.RoleId != 1)
            {
                MessageBox.Show("Выберите ученика");
                return;
            }
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var panel = _moveStudentFactory.Create(context, user);
            panel.StudentMoved += (_, __) => LoadStudents();
            ShowControl(panel);
        }


        private void ButtonAssignTeacherClasses_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser(dataGridViewTeachers);
            if (user == null || user.RoleId != 2)
            {
                MessageBox.Show("Выберите учителя");
                return;
            }
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var panel = _assignFactory.Create(context, user);
            ShowControl(panel);
        }

        private void ButtonCreateClass_Click(object sender, EventArgs e)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var panel = _createClassFactory.Create(context);
            ShowControl(panel);
        }


    }
}

