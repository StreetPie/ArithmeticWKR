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
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxPassword;
        private DateTimePicker dateTimePickerDOB;
        private ComboBox comboBoxClass;
        private Button buttonRegister;
        private Button buttonBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelFirstName = new Label();
            this.labelLastName = new Label();
            this.labelPassword = new Label();
            this.labelDOB = new Label();
            this.labelClass = new Label();
            this.textBoxFirstName = new TextBox();
            this.textBoxLastName = new TextBox();
            this.textBoxPassword = new TextBox();
            this.dateTimePickerDOB = new DateTimePicker();
            this.comboBoxClass = new ComboBox();
            this.buttonRegister = new Button();
            this.buttonBack = new Button();
            this.SuspendLayout();

            // labelFirstName
            this.labelFirstName.Text = "Имя:";
            this.labelFirstName.Location = new Point(30, 30);

            // textBoxFirstName
            this.textBoxFirstName.Location = new Point(150, 30);

            // labelLastName
            this.labelLastName.Text = "Фамилия:";
            this.labelLastName.Location = new Point(30, 70);

            // textBoxLastName
            this.textBoxLastName.Location = new Point(150, 70);

            // labelPassword
            this.labelPassword.Text = "Пароль:";
            this.labelPassword.Location = new Point(30, 110);

            // textBoxPassword
            this.textBoxPassword.Location = new Point(150, 110);
            this.textBoxPassword.UseSystemPasswordChar = true;

            // labelDOB
            this.labelDOB.Text = "Дата рождения:";
            this.labelDOB.Location = new Point(30, 150);

            // dateTimePickerDOB
            this.dateTimePickerDOB.Location = new Point(150, 150);

            // labelClass
            this.labelClass.Text = "Класс:";
            this.labelClass.Location = new Point(30, 190);

            // comboBoxClass
            this.comboBoxClass.Location = new Point(150, 190);

            // buttonRegister
            this.buttonRegister.Text = "Зарегистрироваться";
            this.buttonRegister.Location = new Point(30, 240);
            this.buttonRegister.Click += new EventHandler(this.buttonRegister_Click);

            // buttonBack
            this.buttonBack.Text = "Назад";
            this.buttonBack.Location = new Point(200, 240);
            this.buttonBack.Click += new EventHandler(this.buttonBack_Click);

            buttonRegister.BackColor = Color.FromArgb(0, 120, 215);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            textBoxPassword.PasswordChar = '•';
            comboBoxClass.DropDownStyle = ComboBoxStyle.DropDownList;

            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.BackColor = Color.LightGray;

            // RegistrationForm
            this.ClientSize = new Size(400, 320);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelDOB);
            this.Controls.Add(this.dateTimePickerDOB);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonBack);
            this.Text = "Регистрация";
            this.Load += new EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
