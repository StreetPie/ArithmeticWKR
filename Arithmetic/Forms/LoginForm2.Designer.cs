
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxClass = new ComboBox();
            comboBoxStudent = new ComboBox();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonBack = new Button();
            radioButtonStudent = new RadioButton();
            radioButtonTeacher = new RadioButton();
            radioButtonAdmin = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // comboBoxClass
            // 
            comboBoxClass.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClass.Location = new Point(150, 80);
            comboBoxClass.Name = "comboBoxClass";
            comboBoxClass.Size = new Size(121, 23);
            comboBoxClass.TabIndex = 2;
            comboBoxClass.SelectedIndexChanged += comboBoxClass_SelectedIndexChanged;
            // 
            // comboBoxStudent
            // 
            comboBoxStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStudent.Location = new Point(150, 120);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new Size(121, 23);
            comboBoxStudent.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(150, 160);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '•';
            textBoxPassword.Size = new Size(100, 23);
            textBoxPassword.TabIndex = 6;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(0, 120, 215);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(30, 250);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 10;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(150, 250);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(75, 23);
            buttonBack.TabIndex = 11;
            buttonBack.Text = "Назад";
            buttonBack.Click += buttonBack_Click;
            // 
            // radioButtonStudent
            // 
            radioButtonStudent.FlatStyle = FlatStyle.Flat;
            radioButtonStudent.Location = new Point(30, 200);
            radioButtonStudent.Name = "radioButtonStudent";
            radioButtonStudent.Size = new Size(104, 24);
            radioButtonStudent.TabIndex = 7;
            radioButtonStudent.Text = "Ученик";
            // 
            // radioButtonTeacher
            // 
            radioButtonTeacher.FlatStyle = FlatStyle.Flat;
            radioButtonTeacher.Location = new Point(146, 200);
            radioButtonTeacher.Name = "radioButtonTeacher";
            radioButtonTeacher.Size = new Size(104, 24);
            radioButtonTeacher.TabIndex = 8;
            radioButtonTeacher.Text = "Учитель";
            // 
            // radioButtonAdmin
            // 
            radioButtonAdmin.FlatStyle = FlatStyle.Flat;
            radioButtonAdmin.Location = new Point(260, 200);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(104, 24);
            radioButtonAdmin.TabIndex = 9;
            radioButtonAdmin.Text = "Админ";
            // 
            // label1
            // 
            label1.Location = new Point(30, 80);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            label1.Text = "Класс:";
            // 
            // label2
            // 
            label2.Location = new Point(30, 120);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 3;
            label2.Text = "ФИО:";
            // 
            // label3
            // 
            label3.Location = new Point(30, 160);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 5;
            label3.Text = "Пароль:";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(523, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "СИРС. Арифметические задачи на совместную работу.";
            // 
            // LoginForm2
            // 
            ClientSize = new Size(548, 366);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(comboBoxClass);
            Controls.Add(label2);
            Controls.Add(comboBoxStudent);
            Controls.Add(label3);
            Controls.Add(textBoxPassword);
            Controls.Add(radioButtonStudent);
            Controls.Add(radioButtonTeacher);
            Controls.Add(radioButtonAdmin);
            Controls.Add(buttonLogin);
            Controls.Add(buttonBack);
            Name = "LoginForm2";
            Text = "Вход";
            Load += LoginForm2_Load;
            ResumeLayout(false);
            PerformLayout();


        }


    }
}
