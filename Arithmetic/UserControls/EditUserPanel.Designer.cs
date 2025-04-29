namespace Arithmetic.UserControls
{
    partial class EditUserPanel
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DateTimePicker datePicker;
        private ComboBox comboClass;
        private Label labelClass;
        private Button btnSave;

        private void InitializeComponent()
        {
            this.txtFirstName = new TextBox { PlaceholderText = "Имя" };
            this.txtLastName = new TextBox { PlaceholderText = "Фамилия" };
            this.datePicker = new DateTimePicker();
            this.comboClass = new ComboBox();
            this.labelClass = new Label { Text = "Класс" };
            this.btnSave = new Button { Text = "Сохранить", BackColor = Color.DodgerBlue, ForeColor = Color.White };

            this.Controls.Add(txtFirstName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(datePicker);
            this.Controls.Add(comboClass);
            this.Controls.Add(labelClass);
            this.Controls.Add(btnSave);

            txtFirstName.SetBounds(20, 20, 250, 30);
            txtLastName.SetBounds(20, 60, 250, 30);
            datePicker.SetBounds(20, 100, 250, 30);
            labelClass.SetBounds(20, 140, 100, 20);
            comboClass.SetBounds(20, 165, 250, 30);
            btnSave.SetBounds(20, 210, 150, 40);

            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;
        }
    }
}
