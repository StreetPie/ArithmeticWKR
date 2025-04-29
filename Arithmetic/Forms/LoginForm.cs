using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Arithmetic.Forms;

namespace Arithmetic
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            EnableBlur();
            this.Opacity = 0;
            FadeInForm();
        }

        private async void FadeInForm()
        {
            while (this.Opacity < 1)
            {
                await Task.Delay(20);
                this.Opacity += 0.05;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using (var scope = Program.AppHost.Services.CreateScope())
            {
                var loginForm2 = scope.ServiceProvider.GetRequiredService<LoginForm2>();
                this.Hide(); // Скрыть
                loginForm2.ShowDialog(); // Ждем закрытия
                EnableBlur();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            using (var scope = Program.AppHost.Services.CreateScope())
            {

                var registrationForm = scope.ServiceProvider.GetRequiredService<RegistrationForm>();
                this.Hide();
                registrationForm.ShowDialog();
                EnableBlur();
            }
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            var exitForm = new ExitConfirmationForm();
            exitForm.ShowDialog();

            if (exitForm.Confirmed)
            {
                Application.Exit();
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
        private void ButtonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonLogin.BackColor = BlueButtonHoverColor;
        }

        private void ButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackColor = BlueButtonColor;
        }
        private void ButtonRegister_MouseEnter(object sender, EventArgs e)
        {
            buttonRegister.BackColor = BlueButtonHoverColor;
        }

        private void ButtonRegister_MouseLeave(object sender, EventArgs e)
        {
            buttonRegister.BackColor = BlueButtonColor;
        }
        private void ButtonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = RedButtonHoverColor;
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = RedButtonColor;
        }


        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
    }
}
