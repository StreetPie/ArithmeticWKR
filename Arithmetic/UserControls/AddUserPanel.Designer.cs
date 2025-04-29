namespace Arithmetic.UserControls
{
    partial class AddUserPanel
    {
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblDOB;
        private Label lblRole;
        private Label lblClass;

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DateTimePicker datePicker;
        private ComboBox comboRole;
        private ComboBox comboClass;
        private Button btnAdd;

        private void InitializeComponent()
        {
            this.lblFirstName = new Label { Text = "Имя:", Location = new Point(20, 20) };
            this.txtFirstName = new TextBox { Location = new Point(150, 20), Width = 200 };

            this.lblLastName = new Label { Text = "Фамилия:", Location = new Point(20, 60) };
            this.txtLastName = new TextBox { Location = new Point(150, 60), Width = 200 };

            this.lblDOB = new Label { Text = "Дата рождения:", Location = new Point(20, 100) };
            this.datePicker = new DateTimePicker { Location = new Point(150, 100), Width = 200 };

            this.lblRole = new Label { Text = "Роль:", Location = new Point(20, 140) };
            this.comboRole = new ComboBox { Location = new Point(150, 140), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            this.comboRole.SelectedIndexChanged += comboRole_SelectedIndexChanged;

            this.lblClass = new Label { Text = "Класс:", Location = new Point(20, 180) };
            this.comboClass = new ComboBox { Location = new Point(150, 180), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            this.btnAdd = new Button
            {
                Text = "Добавить",
                Location = new Point(150, 230),
                Width = 200,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Click += btnAdd_Click;

            this.Controls.AddRange(new Control[]
            {
                lblFirstName, txtFirstName,
                lblLastName, txtLastName,
                lblDOB, datePicker,
                lblRole, comboRole,
                lblClass, comboClass,
                btnAdd
            });

            this.Size = new Size(400, 300);
        }
    }
}
