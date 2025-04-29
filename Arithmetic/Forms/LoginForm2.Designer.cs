
namespace Arithmetic
{
    partial class LoginForm2
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxClass;
        private ComboBox comboBoxStudent;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonBack;
        private RadioButton radioButtonStudent;
        private RadioButton radioButtonTeacher;
        private RadioButton radioButtonAdmin;
        private Label labelClass;
        private Label labelStudent;
        private Label labelPassword;
        private Label labelTitle;

        // Константы цветов
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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(0, 0);
            this.KeyDown += LoginForm2_KeyDown;

            labelTitle = new Label
            {
                Text = "СИРС. Арифметические задачи",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                AutoSize = false,
                Size = new Size(1200, 100),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - 1200) / 2, 50)
            };

            labelClass = new Label
            {
                Text = "Класс:",
                Location = new Point(600, 200),
                Font = new Font("Segoe UI", 20F),
                Size = new Size(150, 50)
            };

            comboBoxClass = new ComboBox
            {
                Location = new Point(750, 200),
                Size = new Size(300, 40),
                Font = new Font("Segoe UI", 18F),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DropDownHeight = 450
            };
            comboBoxClass.SelectedIndexChanged += comboBoxClass_SelectedIndexChanged;

            labelStudent = new Label
            {
                Text = "ФИО:",
                Location = new Point(600, 270),
                Font = new Font("Segoe UI", 20F),
                Size = new Size(150, 50)

            };


            comboBoxStudent = new ComboBox
            {
                Location = new Point(750, 270),
                Size = new Size(300, 40),
                Font = new Font("Segoe UI", 18F),
                DropDownStyle = ComboBoxStyle.DropDown,
                DropDownHeight = 450
            };

            labelPassword = new Label
            {
                Text = "Пароль:",
                Location = new Point(600, 340),
                Font = new Font("Segoe UI", 20F),
                Size = new Size(150, 50)
            };

            textBoxPassword = new TextBox
            {
                Location = new Point(750, 340),
                Size = new Size(300, 40),
                Font = new Font("Segoe UI", 18F),
                UseSystemPasswordChar = true
            };

            radioButtonStudent = new RadioButton
            {
                Text = "Ученик",
                Location = new Point(600, 420),
                Size = new Size(150, 50),

                Font = new Font("Segoe UI", 18F),
                Checked = true
            };
            radioButtonStudent.CheckedChanged += radioButtonStudent_CheckedChanged;

            radioButtonTeacher = new RadioButton
            {
                Text = "Учитель",
                Location = new Point(750, 420),
                Font = new Font("Segoe UI", 18F),
                Size = new Size(150, 50),

            };
            radioButtonTeacher.CheckedChanged += radioButtonTeacher_CheckedChanged;

            radioButtonAdmin = new RadioButton
            {
                Text = "Админ",
                Location = new Point(900, 420),
                Font = new Font("Segoe UI", 18F),
                Size = new Size(150, 50),

                Visible = false
            };
            radioButtonAdmin.CheckedChanged += radioButtonAdmin_CheckedChanged;

            int buttonWidth = 300;
            int buttonHeight = 70;
            int centerX = Screen.PrimaryScreen.Bounds.Width / 2;
            int startY = 180;
            int spacingY = 70;

            // Лейблы и поля
            labelClass.Location = new Point(centerX - 350, startY);
            comboBoxClass.Location = new Point(centerX - 150, startY);

            labelStudent.Location = new Point(centerX - 350, startY + spacingY);
            comboBoxStudent.Location = new Point(centerX - 150, startY + spacingY);

            labelPassword.Location = new Point(centerX - 350, startY + 2 * spacingY);
            textBoxPassword.Location = new Point(centerX - 150, startY + 2 * spacingY);

            radioButtonStudent.Location = new Point(centerX - 150, startY + 3 * spacingY);
            radioButtonTeacher.Location = new Point(centerX + 50, startY + 3 * spacingY);
            radioButtonAdmin.Location = new Point(centerX + 250, startY + 3 * spacingY);

            // Кнопка Войти
            // Кнопка Войти
            buttonLogin = new Button
            {
                Text = "Войти",
                Size = new Size(buttonWidth, buttonHeight),
                BackColor = BlueButtonColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Click += buttonLogin_Click;
            buttonLogin.MouseEnter += ButtonLogin_MouseEnter;
            buttonLogin.MouseLeave += ButtonLogin_MouseLeave;
            buttonLogin.Location = new Point(centerX - 350, startY + 4 * spacingY); // СОВПАДАЕТ С labelClass

            // Кнопка Назад
            buttonBack = new Button
            {
                Text = "Назад",
                Size = new Size(buttonWidth, buttonHeight),
                BackColor = RedButtonColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.Click += buttonBack_Click;
            buttonBack.MouseEnter += ButtonBack_MouseEnter;
            buttonBack.MouseLeave += ButtonBack_MouseLeave;
            buttonBack.Location = new Point(centerX - 350 + buttonWidth + 40, startY + 4 * spacingY);


            // Добавляем на форму
            Controls.Add(labelTitle);
            Controls.Add(labelClass);
            Controls.Add(comboBoxClass);
            Controls.Add(labelStudent);
            Controls.Add(comboBoxStudent);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(radioButtonStudent);
            Controls.Add(radioButtonTeacher);
            Controls.Add(radioButtonAdmin);
            Controls.Add(buttonLogin);
            Controls.Add(buttonBack);

            this.Load += LoginForm2_Load;




        }
    }
}