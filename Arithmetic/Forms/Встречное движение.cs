using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Встречное_движение : Form
    {
        private const string CorrectAnswer = "78";
        public Встречное_движение()
        {
            InitializeComponent();
            button4.Enabled = false;
            labelUserName.Text = $"Пользователь: {
                .UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем ответ из текстового поля
            string userAnswer = textBox1.Text.Trim();

            // Проверяем, является ли ответ правильным
            if (userAnswer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Правильный ответ!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Встречное_движение2 встречное_Движение2 = new Встречное_движение2();
                this.Hide();
                встречное_Движение2.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Неправильный ответ. Хотите посмотреть решение?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // Если пользователь выбрал "Да", показываем решение
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Enabled = true; // Разблокируем кнопку "Помощь"
                    Встречное_движение_п_о встречное_Движение_П_О = new Встречное_движение_п_о();
                    this.Hide();
                    встречное_Движение_П_О.ShowDialog();
                }
                else
                {
                    button4.Enabled = false; // Блокируем кнопку "Помощь"
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Средние средние = new Средние();
            this.Hide();
            средние.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Встречное_движение_п_о встречное_Движение_П_О = new Встречное_движение_п_о();
            this.Hide();
            встречное_Движение_П_О.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._12);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }
    }
}
