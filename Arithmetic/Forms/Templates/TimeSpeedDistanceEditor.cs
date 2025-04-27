using Arithmetic.Database;
using Microsoft.Extensions.DependencyInjection;
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

        private void SaveTaskToDatabase()
        {
            try
            {
                using (var scope = Program.AppHost.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var newTask = new Arithmetic.Models.SchoolTask
                    {
                        Text = this.GeneratedTaskText,
                        Answer = this.CorrectAnswer,
                        Type = 0, // Тип задачи - можно потом сделать Enum
                        Difficulty = this.Difficulty, // 0, 1, 2
                        ParagraphId = 1, // Пока временно 1. Потом будет выбирать раздел учитель
                        HasImage = SelectedImagePath != null, 
                        // HasImage = this.SelectedImagePath != null ? Path.GetFileName(this.SelectedImagePath) : null,
                        HasAudio = checkBoxHasAudio.Checked

                    };

                    db.SchoolTasks.Add(newTask);
                    db.SaveChanges();

                    MessageBox.Show("Задача успешно сохранена в базу данных!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Можно после сохранения закрыть конструктор
                    Form parentForm = this.FindForm();
                    parentForm?.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}\n{ex.InnerException?.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

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
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void buttonOpenAudioSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://apihost.ru/voice",
                UseShellExecute = true
            });
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            numericUpDownSpeed.Value = 10;
            numericUpDownDistance.Value = 40;
            comboBoxDifficulty.SelectedIndex = 0;
            pictureBoxBear.Image = null;
            UpdatePreview();
            MessageBox.Show("Форма успешно очищена!", "Очистка формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdatePreview()
        {
            if (numericUpDownSpeed.Value == 0 || numericUpDownDistance.Value == 0)
            {
                richTextBoxPreview.Text = "Ошибка: скорость и расстояние должны быть больше нуля!";
                labelAnswer.Text = "Ответ: -";
            }
            else
            {
                richTextBoxPreview.Text = GeneratedTaskText;
                labelAnswer.Text = $"Ответ: {CorrectAnswer} часов";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите сохранить задачу?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveTaskToDatabase();
                MessageBox.Show("Задача успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Сохранение отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите выйти без сохранения?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                parentForm?.Close();
            }
        }
    }
}
