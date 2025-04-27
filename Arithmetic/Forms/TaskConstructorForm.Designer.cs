namespace Arithmetic.Forms
{
    partial class TaskConstructorForm
    {
        private ComboBox comboBoxTemplates;
        private Panel panelTemplateHolder;
        private Button buttonSave;

        private void InitializeComponent()
        {
            comboBoxTemplates = new ComboBox();
            panelTemplateHolder = new Panel();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // comboBoxTemplates
            // 
            comboBoxTemplates.Font = new Font("Segoe UI", 24F);
            comboBoxTemplates.Location = new Point(30, 20);
            comboBoxTemplates.Name = "comboBoxTemplates";
            comboBoxTemplates.Size = new Size(600, 53);
            comboBoxTemplates.TabIndex = 0;
            // 
            // panelTemplateHolder
            // 
            panelTemplateHolder.BorderStyle = BorderStyle.FixedSingle;
            panelTemplateHolder.Location = new Point(30, 100);
            panelTemplateHolder.Name = "panelTemplateHolder";
            panelTemplateHolder.Size = new Size(1850, 950);
            panelTemplateHolder.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(30, 300);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(150, 40);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить задачу";
            buttonSave.Click += buttonSave_Click;
            // 
            // TaskConstructorForm
            // 
            ClientSize = new Size(1920, 1039);
            Controls.Add(comboBoxTemplates);
            Controls.Add(panelTemplateHolder);
            Name = "TaskConstructorForm";
            Text = "Конструктор задач";
            ResumeLayout(false);
        }
    }
}