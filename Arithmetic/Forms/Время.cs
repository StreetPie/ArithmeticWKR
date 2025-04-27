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
    public partial class Время : Form
    {
        private const string CorrectAnswer = "4";
        public Время()
        {
            InitializeComponent();
            button4.Enabled = false; // Изначально кнопка заблокирована
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
                    Время_п_о время_П_О = new Время_п_о();
                    this.Hide();
                    время_П_О.ShowDialog();
                }
                else
                {
                    button4.Enabled = false; // Блокируем кнопку "Помощь"
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Помощь2 помощь2 = new Помощь2();
            this.Hide();
            помощь2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Легкие легкие = new Легкие();
            this.Hide();
            легкие.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Время_п_о время_П_О = new Время_п_о();
            this.Hide();
            время_П_О.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._6);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }

        private void Время_Load(object sender, EventArgs e)
        {

        }
    }
}
