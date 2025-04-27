namespace Arithmetic
{
    partial class LoginForm
    {
        private Button buttonLogin;
        private Button buttonRegister;
        private Button buttonExit;
        private Label label1;
        private Label label2;

        private void InitializeComponent()
        {
            buttonLogin = new Button();
            buttonRegister = new Button();
            buttonExit = new Button();
            label3 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonLogin
            // 
            buttonLogin.Font = new Font("Segoe UI", 16F);
            buttonLogin.Location = new Point(600, 250);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(300, 60);
            buttonLogin.TabIndex = 0;
            buttonLogin.Text = "Войти";
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Font = new Font("Segoe UI", 16F);
            buttonRegister.Location = new Point(600, 350);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(300, 60);
            buttonRegister.TabIndex = 1;
            buttonRegister.Text = "Регистрация";
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonExit
            // 
            buttonExit.Font = new Font("Segoe UI", 16F);
            buttonExit.Location = new Point(600, 450);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(300, 60);
            buttonExit.TabIndex = 2;
            buttonExit.Text = "Выход";
            buttonExit.Click += buttonExit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(591, 104);
            label3.Name = "label3";
            label3.Size = new Size(309, 15);
            label3.TabIndex = 3;
            label3.Text = "СИРС. Арифметические задачи на совместную работу";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(600, 188);
            label1.Name = "label1";
            label1.Size = new Size(274, 15);
            label1.TabIndex = 4;
            label1.Text = " Арифметические задачи на совместную работу";
            label1.Click += label1_Click_1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 800);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(buttonLogin);
            Controls.Add(buttonRegister);
            Controls.Add(buttonExit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добро пожаловать";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }
        private Label label3;
    }
}
