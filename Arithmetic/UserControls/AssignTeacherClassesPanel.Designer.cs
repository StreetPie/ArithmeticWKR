namespace Arithmetic.UserControls
{
    partial class AssignTeacherClassesPanel
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelTeacher;
        private CheckedListBox checkedListBoxClasses;
        private Button btnSave;

        private void InitializeComponent()
        {
            this.labelTeacher = new Label();
            this.checkedListBoxClasses = new CheckedListBox();
            this.btnSave = new Button();

            this.labelTeacher.SetBounds(20, 20, 400, 30);
            this.checkedListBoxClasses.SetBounds(20, 60, 300, 300);
            this.btnSave.SetBounds(20, 380, 150, 40);

            this.btnSave.Text = "Сохранить";
            this.btnSave.BackColor = Color.DodgerBlue;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;

            this.btnSave.Click += btnSave_Click;

            this.Controls.Add(labelTeacher);
            this.Controls.Add(checkedListBoxClasses);
            this.Controls.Add(btnSave);
        }
    }
}
