namespace Arithmetic.Forms
{
    partial class TeacherForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelWelcome;
        private Button buttonTaskConstructor; 

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelWelcome = new Label();
            buttonTaskConstructor = new Button();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.Location = new Point(26, 84);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(350, 30);
            labelWelcome.TabIndex = 1;
            labelWelcome.Text = "Добро пожаловать, учитель!";
            // 
            // buttonTaskConstructor
            // 
            buttonTaskConstructor.Location = new Point(26, 22);
            buttonTaskConstructor.Margin = new Padding(3, 2, 3, 2);
            buttonTaskConstructor.Name = "buttonTaskConstructor";
            buttonTaskConstructor.Size = new Size(163, 51);
            buttonTaskConstructor.TabIndex = 0;
            buttonTaskConstructor.Text = "Конструктор задач";
            buttonTaskConstructor.UseVisualStyleBackColor = true;
            buttonTaskConstructor.Click += buttonTaskConstructor_Click;
            // 
            // TeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 300);
            Controls.Add(buttonTaskConstructor);
            Controls.Add(labelWelcome);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TeacherForm";
            Text = "Панель учителя";
            Load += TeacherForm_Load;
            ResumeLayout(false);
        }
    }
}
