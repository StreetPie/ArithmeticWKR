namespace Arithmetic.UserControls
{
    partial class MoveStudentPanel
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelCurrentClass;
        private ComboBox comboClasses;
        private Button btnMove;

        private void InitializeComponent()
        {
            this.labelCurrentClass = new Label();
            this.comboClasses = new ComboBox();
            this.btnMove = new Button();

            this.labelCurrentClass.SetBounds(20, 20, 300, 25);
            this.comboClasses.SetBounds(20, 60, 250, 30);
            this.btnMove.SetBounds(20, 110, 150, 40);

            this.labelCurrentClass.Text = "Текущий класс:";
            this.btnMove.Text = "Перевести";
            this.btnMove.BackColor = Color.DodgerBlue;
            this.btnMove.ForeColor = Color.White;
            this.btnMove.FlatStyle = FlatStyle.Flat;
            this.btnMove.FlatAppearance.BorderSize = 0;

            this.btnMove.Click += btnMove_Click;

            this.Controls.Add(labelCurrentClass);
            this.Controls.Add(comboClasses);
            this.Controls.Add(btnMove);
        }
    }
}
