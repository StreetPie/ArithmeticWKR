namespace Arithmetic
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelFirstName;
        private Label labelLastName;
        private Label labelPassword;
        private Label labelDOB;
        private Label labelClass;
        private Label labelTitle;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxPassword;
        private MaskedTextBox maskedTextBoxDOB;
        private Button buttonCalendar;
        private MonthCalendar monthCalendar;
        private ComboBox comboBoxClass;
        private Button buttonRegister;
        private Button buttonBack;



        //цвета
        private readonly Color BlueButtonColor = Color.DodgerBlue;
        private readonly Color BlueButtonHoverColor = Color.DeepSkyBlue;
        private readonly Color RedButtonColor = Color.IndianRed;
        private readonly Color RedButtonHoverColor = Color.FromArgb(220, 20, 60);

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(245, 250, 255);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Регистрация";

            int centerX = Screen.PrimaryScreen.Bounds.Width / 2;
            int startY = 180;
            int spacingY = 70;

            labelTitle = new Label
            {
                Text = "СИРС. Регистрация ученика",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                AutoSize = false,
                Size = new Size(1200, 100),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - 1200) / 2, 50)
            };

            labelFirstName = new Label { Text = "Имя:", Font = new Font("Segoe UI", 20F), Location = new Point(centerX - 350, startY), Size = new Size(150, 50) };
            textBoxFirstName = new TextBox { Font = new Font("Segoe UI", 18F), Location = new Point(centerX - 150, startY), Size = new Size(300, 40) };

            labelLastName = new Label { Text = "Фамилия:", Font = new Font("Segoe UI", 20F), Location = new Point(centerX - 350, startY + spacingY), Size = new Size(150, 50) };
            textBoxLastName = new TextBox { Font = new Font("Segoe UI", 18F), Location = new Point(centerX - 150, startY + spacingY), Size = new Size(300, 40) };

            labelPassword = new Label { Text = "Пароль:", Font = new Font("Segoe UI", 20F), Location = new Point(centerX - 350, startY + 2 * spacingY), Size = new Size(150, 50) };
            textBoxPassword = new TextBox { Font = new Font("Segoe UI", 18F), Location = new Point(centerX - 150, startY + 2 * spacingY), Size = new Size(300, 40), UseSystemPasswordChar = true };

            labelDOB = new Label { Text = "Дата рождения:", Font = new Font("Segoe UI", 20F), Location = new Point(centerX - 350, startY + 3 * spacingY), Size = new Size(250, 50) };


            buttonCalendar = new Button
            {
                Text = "📅",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Size = new Size(40, 40),
                Location = new Point(centerX + 60, startY + 3 * spacingY),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray
            };
            buttonCalendar.FlatAppearance.BorderSize = 0;

            maskedTextBoxDOB = new MaskedTextBox
            {
                Font = new Font("Segoe UI", 18F),
                Location = new Point(centerX - 150, startY + 3 * spacingY),
                Size = new Size(170, 40),
                Mask = "00.00.0000",
                ValidatingType = typeof(DateTime),
                    PromptChar = '_',
                TextAlign = HorizontalAlignment.Right,
            };

            monthCalendar = new MonthCalendar
            {
                MaxSelectionCount = 1,
                Visible = false,
                Location = new Point(centerX - 150, startY + 3 * spacingY + 50)
            };
            monthCalendar.DateSelected += (s, e) =>
            {
                maskedTextBoxDOB.Text = e.Start.ToString("dd.MM.yyyy");
                monthCalendar.Visible = false;
            };

            buttonCalendar.Click += (s, e) =>
            {
                monthCalendar.Visible = !monthCalendar.Visible;
            };



            labelClass = new Label { Text = "Класс:", Font = new Font("Segoe UI", 20F), Location = new Point(centerX - 350, startY + 4 * spacingY), Size = new Size(150, 50) };
            comboBoxClass = new ComboBox { Font = new Font("Segoe UI", 18F), Location = new Point(centerX - 150, startY + 4 * spacingY), Size = new Size(300, 40), DropDownHeight = 450 };

            buttonRegister = new Button
            {
                Text = "Зарегистрироваться",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                BackColor = BlueButtonColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(300, 70),
                Location = new Point(centerX - 350, startY + 5 * spacingY)
            };
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.Click += buttonRegister_Click;
            buttonRegister.MouseEnter += ButtonRegister_MouseEnter;
            buttonRegister.MouseLeave += ButtonRegister_MouseLeave;

            buttonBack = new Button
            {
                Text = "Назад",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                BackColor = RedButtonColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(300, 70),
                Location = new Point(centerX + 50, startY + 5 * spacingY)
            };
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.Click += buttonBack_Click;
            buttonBack.MouseEnter += ButtonBack_MouseEnter;
            buttonBack.MouseLeave += ButtonBack_MouseLeave;

            Controls.Add(labelTitle);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxFirstName);
            Controls.Add(labelLastName);
            Controls.Add(textBoxLastName);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelDOB);
            Controls.Add(maskedTextBoxDOB);
            Controls.Add(buttonCalendar);
            Controls.Add(monthCalendar);
            Controls.Add(labelClass);
            Controls.Add(comboBoxClass);
            Controls.Add(buttonRegister);
            Controls.Add(buttonBack);


            this.Load += RegistrationForm_Load;
        }

    }
}
