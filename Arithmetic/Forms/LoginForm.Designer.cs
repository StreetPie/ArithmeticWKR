using System.Windows.Forms;

namespace Arithmetic
{
    partial class LoginForm
    {
        private Button buttonLogin;
        private Button buttonRegister;
        private Button buttonExit;
        private Label labelTitle;
        // Константы цветов
        private readonly Color BlueButtonColor = Color.DodgerBlue;
        private readonly Color BlueButtonHoverColor = Color.DeepSkyBlue;
        private readonly Color RedButtonColor = Color.IndianRed;
        private readonly Color RedButtonHoverColor = Color.FromArgb(220, 20, 60);


        private void InitializeComponent()
        {
            this.buttonLogin = new Button();
            this.buttonRegister = new Button();
            this.buttonExit = new Button();
            this.labelTitle = new Label();
            this.SuspendLayout();

            // Label Title
            this.labelTitle.Text = "СИРС\nАрифметические задачи на совместную работу";
            this.labelTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.MidnightBlue;
            this.labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.labelTitle.Size = new Size(1200, 200);
            this.labelTitle.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.labelTitle.Width) / 2, 50);

            // buttonLogin
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.buttonLogin.Size = new Size(400, 90);
            this.buttonLogin.Location = new Point((Screen.PrimaryScreen.Bounds.Width - 400) / 2, 300);
            this.buttonLogin.BackColor = BlueButtonColor;
            this.buttonLogin.ForeColor = Color.White;
            this.buttonLogin.FlatStyle = FlatStyle.Flat;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.MouseEnter += ButtonLogin_MouseEnter;
            buttonLogin.MouseLeave += ButtonLogin_MouseLeave;
            this.buttonLogin.Click += buttonLogin_Click;

            // buttonRegister
            this.buttonRegister.Text = "Регистрация";
            this.buttonRegister.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.buttonRegister.Size = new Size(400, 90);
            this.buttonRegister.Location = new Point((Screen.PrimaryScreen.Bounds.Width - 400) / 2, 420);
            this.buttonRegister.BackColor = BlueButtonColor;
            this.buttonRegister.ForeColor = Color.White;
            this.buttonRegister.FlatStyle = FlatStyle.Flat;
            this.buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.MouseEnter += ButtonRegister_MouseEnter;
            buttonRegister.MouseLeave += ButtonRegister_MouseLeave;
            this.buttonRegister.Click += buttonRegister_Click;


            // buttonExit
            this.buttonExit.Text = "Выход";
            this.buttonExit.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.buttonExit.Size = new Size(400, 90);
            this.buttonExit.Location = new Point((Screen.PrimaryScreen.Bounds.Width - 400) / 2, 540);
            this.buttonExit.BackColor = RedButtonColor;
            this.buttonExit.ForeColor = Color.White;
            this.buttonExit.FlatStyle = FlatStyle.Flat;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.MouseEnter += ButtonExit_MouseEnter;
            buttonExit.MouseLeave += ButtonExit_MouseLeave;

            this.buttonExit.Click += buttonExit_Click;


            // LoginForm
            this.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Добро пожаловать в СИРС";
            this.ResumeLayout(false);
        }
    }
}
