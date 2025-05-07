using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arithmetic.UserControls
{
    public partial class EditUserPanel : UserControl  // Наследуем от UserControl
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DateTimePicker datePicker;
        private ComboBox comboClass;
        private Label labelClass;
        private Button btnSave;

        public EditUserPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            datePicker = new DateTimePicker();
            comboClass = new ComboBox();
            labelClass = new Label();
            btnSave = new Button();

            SuspendLayout();

            // txtFirstName
            txtFirstName.Location = new Point(20, 30);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(250, 23);
            txtFirstName.TabIndex = 0;
            txtFirstName.PlaceholderText = "Имя";

            // txtLastName
            txtLastName.Location = new Point(20, 70);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(250, 23);
            txtLastName.TabIndex = 1;
            txtLastName.PlaceholderText = "Фамилия";

            // datePicker
            datePicker.Location = new Point(20, 110);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(250, 23);
            datePicker.TabIndex = 2;

            // labelClass
            labelClass.AutoSize = true;
            labelClass.Location = new Point(20, 150);
            labelClass.Name = "labelClass";
            labelClass.Size = new Size(39, 15);
            labelClass.TabIndex = 3;
            labelClass.Text = "Класс";

            // comboClass
            comboClass.Location = new Point(20, 170);
            comboClass.Name = "comboClass";
            comboClass.Size = new Size(250, 23);
            comboClass.TabIndex = 4;

            // btnSave
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(20, 210);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // EditUserPanel
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Controls.Add(datePicker);
            Controls.Add(labelClass);
            Controls.Add(comboClass);
            Controls.Add(btnSave);
            Name = "EditUserPanel";
            Size = new Size(300, 270);

            ResumeLayout(false);
            PerformLayout();
        }


      
    }
}
