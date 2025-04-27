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
    public partial class Противоположные_направления : Form
    {
        // Правильный ответ
        private const string CorrectAnswer = "4";
        public Противоположные_направления()
        {
            InitializeComponent();
            button4.Enabled = false;
            labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {
                .UserSurname} {AuthInfo.UserClass}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем ответ из текстового поля
            string userAnswer = textBox1.Text.Trim();

            // Проверяем, является ли ответ правильным
            if (userAnswer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Правильный ответ!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Противоположное_направление2 противоположное_Направление2 = new Противоположное_направление2();
                this.Hide();
                противоположное_Направление2.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Неправильный ответ. Хотите посмотреть решение?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // Если пользователь выбрал "Да", показываем решение
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Enabled = true; // Разблокируем кнопку "Помощь"
                    Противоположное_направление_п_о противоположное_Направление_П_О = new Противоположное_направление_п_о();
                    this.Hide();
                    противоположное_Направление_П_О.ShowDialog();
                }
                else
                {
                    button4.Enabled = false; // Блокируем кнопку "Помощь"
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Средние средние = new Средние();
            this.Hide();
            средние.ShowDialog();
        }

        private void Противоположные_направления_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Противоположное_направление_п_о противоположное_Направление_П_О = new Противоположное_направление_п_о();
            this.Hide();
            противоположное_Направление_П_О.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._24);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
