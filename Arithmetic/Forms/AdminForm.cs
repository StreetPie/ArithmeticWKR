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
        private readonly AppDbContext _context;


        private readonly IServiceProvider _provider;

        public AdminForm(
            AppDbContext context,
            IFormFactory<AddUserPanel> addUserFactory,
            IFormFactory<AssignTeacherClassesPanel> assignFactory,
            IFormFactory<CreateClassPanel> createClassFactory,
            IFormFactory<EditUserPanel> editUserFactory,
            IFormFactory<MoveStudentPanel> moveStudentFactory,
            IFormFactory<ResetPasswordPanel> resetPasswordFactory)
        {
            _context = context;
            _addUserFactory = addUserFactory;
            _assignFactory = assignFactory;
            _createClassFactory = createClassFactory;
            _editUserFactory = editUserFactory;
            _moveStudentFactory = moveStudentFactory;
            _resetPasswordFactory = resetPasswordFactory;
            EnableBlur();
            InitializeComponent();
        }



        private void ShowControl(UserControl control)
        {
            panelRightContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelRightContainer.Controls.Add(control);
            panelRightContainer.Visible = true;
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

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private void LoadTeachers()
        {
            var teachers = _context.Users
                .Where(u => u.RoleId == 2)
                .Select(u => new
                {
                    u.Id,
                    Имя = u.FirstName,
                    Фамилия = u.LastName,
                    Дата_рождения = u.DateOfBirth.ToShortDateString(),
                    Зарегистрирован = u.RegistrationDate.ToShortDateString()
                })
                .ToList();

            dataGridViewTeachers.DataSource = teachers;
        }

        private void LoadStudents()
        {
            var students = _context.Users
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

            dataGridViewStudents.DataSource = students;
        }

        private User GetSelectedUser(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
                return null;

            int userId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
            return _context.Users.Include(u => u.Class).FirstOrDefault(u => u.Id == userId);
        }

        private void ButtonAddUser_Click(object sender, EventArgs e)
        {
            var panel = _addUserFactory.Create(_context);
            panel.OnUserAdded += () =>
            {
                LoadTeachers();
                LoadStudents();
            };
            ShowControl(panel);
        }


        private void ButtonEditUser_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser(dataGridViewTeachers) ?? GetSelectedUser(dataGridViewStudents);
            if (user == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

            var panel = _editUserFactory.Create(_context, user);
            panel.UserUpdated += (_, __) =>
            {
                LoadTeachers();
                LoadStudents();
            };
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

            var confirm = MessageBox.Show("Удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
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

            var panel = _resetPasswordFactory.Create(_context, user);
            ShowControl(panel);
        }


        private void ButtonMoveStudent_Click(object sender, EventArgs e)
        {
            var student = GetSelectedUser(dataGridViewStudents);
            if (student == null || student.RoleId != 1)
            {
                MessageBox.Show("Выберите ученика");
                return;
            }

            var panel = _moveStudentFactory.Create(_context, student);
            panel.StudentMoved += (_, __) => LoadStudents();
            ShowControl(panel);
        }


        private void ButtonAssignTeacherClasses_Click(object sender, EventArgs e)
        {
            var teacher = GetSelectedUser(dataGridViewTeachers);
            if (teacher == null || teacher.RoleId != 2)
            {
                MessageBox.Show("Выберите учителя");
                return;
            }

            var panel = _assignFactory.Create(_context, teacher);
            ShowControl(panel);
        }

        private void ButtonCreateClass_Click(object sender, EventArgs e)
        {
            var panel = _createClassFactory.Create(_context);
            ShowControl(panel);
        }

    }
}

