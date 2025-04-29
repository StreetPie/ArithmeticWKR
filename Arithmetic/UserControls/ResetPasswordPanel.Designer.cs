namespace Arithmetic.UserControls
{
    partial class ResetPasswordPanel
    {
        private Label labelUser;
        private TextBox textBoxPassword;
        private Button btnReset;
        private Button btnCancel;

        private void InitializeComponent()
        {
            this.labelUser = new Label();
            this.textBoxPassword = new TextBox();
            this.btnReset = new Button();
            this.btnCancel = new Button();

            // labelUser
            this.labelUser.Location = new Point(20, 20);
            this.labelUser.Size = new Size(300, 30);
            this.labelUser.Font = new Font("Segoe UI", 10);

            // textBoxPassword
            this.textBoxPassword.Location = new Point(20, 60);
            this.textBoxPassword.Size = new Size(300, 30);
            this.textBoxPassword.Font = new Font("Segoe UI", 10);
            this.textBoxPassword.PasswordChar = '*';

            // btnReset
            this.btnReset.Text = "Сбросить пароль";
            this.btnReset.Location = new Point(20, 110);
            this.btnReset.Size = new Size(140, 35);
            this.btnReset.BackColor = Color.IndianRed;
            this.btnReset.ForeColor = Color.White;
            this.btnReset.FlatStyle = FlatStyle.Flat;
            this.btnReset.Click += btnReset_Click;

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new Point(180, 110);
            this.btnCancel.Size = new Size(140, 35);
            this.btnCancel.BackColor = Color.Gray;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Click += btnCancel_Click;

            // Panel
            this.Controls.Add(labelUser);
            this.Controls.Add(textBoxPassword);
            this.Controls.Add(btnReset);
            this.Controls.Add(btnCancel);
            this.Size = new Size(350, 170);
            this.BackColor = Color.White;
        }
    }
}
