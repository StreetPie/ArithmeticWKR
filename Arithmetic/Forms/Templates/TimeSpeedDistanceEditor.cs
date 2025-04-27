using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arithmetic.Forms.Templates
{
    public partial class TimeSpeedDistanceEditor : UserControl
    {
        private readonly Random random = new Random();
        private readonly string[] bearImages = new string[]
        {
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "bear_white.jpg"),
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "bear_brown.jpg"),
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "bear_polar.jpeg")
        };


        public TimeSpeedDistanceEditor()
        {
            InitializeComponent();
            comboBoxDifficulty.SelectedIndex = 0; // По умолчанию "Легкая"
        }

        public string GeneratedTaskText =>
            $"Скорость медведя {numericUpDownSpeed.Value} км/ч. " +
            $"Сколько времени потребуется ему, чтобы проплыть {numericUpDownDistance.Value} км?";

        public string CorrectAnswer =>
            (numericUpDownDistance.Value / numericUpDownSpeed.Value).ToString("0.##");

        public int Difficulty => comboBoxDifficulty.SelectedIndex; // 0: Легкая, 1: Средняя, 2: Сложная

        public string SelectedImagePath { get; private set; }

        private void buttonRandomImage_Click(object sender, EventArgs e)
        {
            var selected = bearImages[random.Next(bearImages.Length)];
            if (File.Exists(selected))
            {
                pictureBoxBear.Image = Image.FromFile(selected);
                SelectedImagePath = selected;
            }
            else
            {
                MessageBox.Show($"Файл изображения не найден: {selected}");
            }
        }
        private void buttonSaveTask_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите сохранить задачу?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               // SaveTaskToDatabase();
                MessageBox.Show("Задача успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Сохранение отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonExitConstructor_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите выйти без сохранения?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                parentForm?.Close();
            }
        }

        private void buttonOpenAudioSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://apihost.ru/voice",
                UseShellExecute = true
            });
        }

        private void UpdatePreview()
        {
            richTextBoxPreview.Text = GeneratedTaskText;
            labelAnswer.Text = $"Ответ: {CorrectAnswer} часов";
        }
    }
}
