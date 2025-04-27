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
    public partial class Скорость : Form
    {
        private const string CorrectAnswer = "32";

        public Скорость()
        {
            InitializeComponent();
            button4.Enabled = false;
            labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем ответ из текстового поля
            string userAnswer = textBox1.Text.Trim();

            // Проверяем, является ли ответ правильным
            if (userAnswer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Правильный ответ!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Время время = new Время();
                this.Hide();
                время.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Неправильный ответ. Хотите посмотреть решение?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // Если пользователь выбрал "Да", показываем решение
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Enabled = true; // Разблокируем кнопку "Помощь"
                    Скорость_п_о скорость_П_О = new Скорость_п_о();
                    this.Hide();
                    скорость_П_О.ShowDialog();
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
            Помощь помощь = new Помощь();
            this.Hide();
            помощь.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Легкие легкие = new Легкие();
            this.Hide();
            легкие.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Скорость_п_о скорость_П_О = new Скорость_п_о();
            this.Hide();
            скорость_П_О.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._28);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }
    }
}
