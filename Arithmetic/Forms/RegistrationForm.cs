using System;
using System.Drawing;
using System.Globalization;
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
    public partial class RegistrationForm : Form
    {
        private readonly AppDbContext _context;

        public RegistrationForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            EnableBlur();

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }


        private void EnableBlur()
        {
            var accent = new AccentPolicy();
            accent.AccentState = 3;
            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData
            {
                Attribute = 19,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

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

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            var classes = _context.Classes.OrderBy(c => c.Name).ToList();
            comboBoxClass.DataSource = classes;
            comboBoxClass.DisplayMember = "Name";
            comboBoxClass.ValueMember = "Id";

            comboBoxClass.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxClass.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxClass.SelectedIndex = -1;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && monthCalendar.Visible)
            {
                monthCalendar.Visible = false;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var firstName = textBoxFirstName.Text.Trim();
            var lastName = textBoxLastName.Text.Trim();
            var password = textBoxPassword.Text.Trim();
            //var birthDate = maskedTextBoxDOB.Value;

            if (!maskedTextBoxDOB.MaskFull)
            {
                MessageBox.Show("Введите полную дату рождения.");
                return;
            }

            if (!DateTime.TryParseExact(maskedTextBoxDOB.Text, "dd,MM,yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
            {
                MessageBox.Show("Введите корректную дату рождения.");
                return;
            }
            if (dob.Year < 1900 || dob > DateTime.Today)
            {
                MessageBox.Show("Дата рождения должна быть в диапазоне от 1900 года до сегодняшнего дня.");
                return;
            }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все обязательные поля.");
                return;
            }

            if (comboBoxClass.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите класс.");
                return;
            }

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                PasswordHash = HashPassword(password),
                DateOfBirth = dob,
                RegistrationDate = DateTime.Now,
                RoleId = 1,
                ClassId = (int)comboBoxClass.SelectedValue
            };


            _context.Users.Add(user);
            _context.SaveChanges();

            using (var scope = Program.AppHost.Services.CreateScope())
            {
                var session = scope.ServiceProvider.GetRequiredService<UserSessionService>();
                session.SetUser(user);

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                session.LoadProgress(context);

                var mainForm = scope.ServiceProvider
                    .GetRequiredService<IFormFactory<MainForm>>()
                    .Create();
                mainForm.Show();
            }

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



        private class ClickOutsideMessageFilter : IMessageFilter
        {
            private readonly Control target;
            private readonly Action onClickOutside;

            public ClickOutsideMessageFilter(Control target, Action onClickOutside)
            {
                this.target = target;
                this.onClickOutside = onClickOutside;
            }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x201) // WM_LBUTTONDOWN
                {
                    Point clickedPoint = Control.MousePosition;
                    if (!target.Bounds.Contains(target.Parent.PointToClient(clickedPoint)))
                    {
                        onClickOutside();
                    }
                }
                return false;
            }
        }

        private void ButtonRegister_MouseEnter(object sender, EventArgs e)
        {
            buttonRegister.BackColor = BlueButtonHoverColor;
        }

        private void ButtonRegister_MouseLeave(object sender, EventArgs e)
        {
            buttonRegister.BackColor = BlueButtonColor;
        }

        private void ButtonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonHoverColor;
        }

        private void ButtonBack_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonColor;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            var loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
