namespace Arithmetic.UserControls
{
    partial class CreateClassPanel
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtClassName;
        private Button btnCreate;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtClassName = new TextBox();
            this.btnCreate = new Button();

            // lblTitle
            this.lblTitle.Text = "Введите название класса:";
            this.lblTitle.SetBounds(20, 30, 300, 30);

            // txtClassName
            this.txtClassName.SetBounds(20, 70, 300, 30);

            // btnCreate
            this.btnCreate.Text = "Создать";
            this.btnCreate.BackColor = Color.DodgerBlue;
            this.btnCreate.ForeColor = Color.White;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.SetBounds(20, 120, 150, 40);
            this.btnCreate.Click += btnCreate_Click;

            // Add to panel
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtClassName);
            this.Controls.Add(btnCreate);
        }
    }
}
