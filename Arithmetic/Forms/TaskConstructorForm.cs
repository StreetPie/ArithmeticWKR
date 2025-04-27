using System;
using System.Windows.Forms;
using Arithmetic.Forms.Templates;


namespace Arithmetic.Forms
{
    public partial class TaskConstructorForm : Form
    {
        private UserControl currentTemplateControl;

        public TaskConstructorForm()
        {
            InitializeComponent();
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            comboBoxTemplates.Items.Add("Скорость-Время-Расстояние");
            comboBoxTemplates.SelectedIndexChanged += ComboBoxTemplates_SelectedIndexChanged;
        }

        private void ComboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelTemplateHolder.Controls.Clear();

            if (comboBoxTemplates.SelectedItem.ToString() == "Скорость-Время-Расстояние")
            {
                var template = new TimeSpeedDistanceEditor();
                currentTemplateControl = template;
                panelTemplateHolder.Controls.Add(template);
                currentTemplateControl.Dock = DockStyle.Fill;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (currentTemplateControl is TimeSpeedDistanceEditor template)
            {
                var taskText = template.GeneratedTaskText;
                var correctAnswer = template.CorrectAnswer;

                MessageBox.Show($"Сохранено задание:\n\n{taskText}\nОтвет: {correctAnswer}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Здесь можно будет сохранить в базу данных SchoolTask
                // Например:
                // context.SchoolTasks.Add(new SchoolTask { Text = taskText, Answer = correctAnswer, ... });
                // context.SaveChanges();
            }
        }
    }
}
