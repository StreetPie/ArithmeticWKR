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
    public partial class На_работу : Form
    {
        private const string CorrectAnswer = "4";
        public На_работу()
        {
            InitializeComponent();
            button4.Enabled = false; // Изначально кнопка заблокирована
            labelUserName.Text = $"Пользователь: {
                .UserName} {AuthInfo.UserSurname}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            На_работу_п_о на_Работу_П_О = new На_работу_п_о();
            this.Hide();
            на_Работу_П_О.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем ответ из текстового поля
            string userAnswer = textBox1.Text.Trim();

            // Проверяем, является ли ответ правильным
            if (userAnswer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Правильный ответ!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Расстояние расстояние = new Расстояние();
                this.Hide();
                расстояние.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Неправильный ответ. Хотите посмотреть решение?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // Если пользователь выбрал "Да", показываем решение
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Enabled = true; // Разблокируем кнопку "Помощь"
                    На_работу_п_о на_Работу_П_О = new На_работу_п_о();
                    this.Hide();
                    на_Работу_П_О.ShowDialog();
                }
                else
                {
                    button4.Enabled = false; // Блокируем кнопку "Помощь"
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Работа работа = new Работа();
            this.Hide();
            работа.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Помощь_4 помощь_4 = new Помощь_4();
            this.Hide();
            помощь_4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._16);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
