namespace Arithmetic.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelWelcome = new Label();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.Dock = DockStyle.Fill;
            this.labelWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.labelWelcome.TextAlign = ContentAlignment.MiddleCenter;
            this.labelWelcome.Text = "Добро пожаловать, администратор!";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 400);
            this.Controls.Add(this.labelWelcome);
            this.Name = "AdminForm";
            this.Text = "Админ-панель";
            this.Load += new EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
        }
    }
}
