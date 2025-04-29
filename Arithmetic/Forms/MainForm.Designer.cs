namespace Arithmetic.Forms
{
    partial class MainForm
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
            this.labelWelcome.Text = "Добро пожаловать!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 400);
            this.Controls.Add(this.labelWelcome);
            this.Name = "MainForm";
            this.Text = "Главное окно";
          //  this.Load += new EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
        }
    }
}
