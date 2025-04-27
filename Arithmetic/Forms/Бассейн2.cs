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
    public partial class Бассейн2 : Form
    {
        // Правильные ответы на вопросы
        private const string CorrectAnswer1 = "1/3; 1/6";
        private const string CorrectAnswer2 = "1/2";
        private const string CorrectAnswer3 = "2";
        public Бассейн2()
        {
            InitializeComponent();
            button4.Enabled = false;
            //labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {AuthInfo.UserSurname} {
            //    .UserClass}";
        }

        private void Бассейн2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем ответы, введенные пользователем
            string answer1 = textBox1.Text.Trim();
            string answer2 = textBox2.Text.Trim();
            string answer3 = textBox3.Text.Trim();

            // Проверяем ответы
            bool isCorrect1 = string.Equals(answer1, CorrectAnswer1, StringComparison.OrdinalIgnoreCase);
            bool isCorrect2 = string.Equals(answer2, CorrectAnswer2, StringComparison.OrdinalIgnoreCase);
            bool isCorrect3 = string.Equals(answer3, CorrectAnswer3, StringComparison.OrdinalIgnoreCase);

            // Отображаем соответствующее сообщение
            if (isCorrect1 && isCorrect2 && isCorrect3)
            {
                MessageBox.Show("Все ответы правильные!", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Работа работа = new Работа();
                this.Hide();
                работа.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Неправильный ответ. Хотите посмотреть решение?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // Если пользователь выбрал "Да", показываем решение
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Enabled = true; // Разблокируем кнопку "Помощь"
                    Бассейн2_п_оcs бассейн2_П_Оcs = new Бассейн2_п_оcs();
                    this.Hide();
                    бассейн2_П_Оcs.ShowDialog();
                }
                else
                {
                    button4.Enabled = false; // Блокируем кнопку "Помощь"
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Работа работа = new Работа();
            this.Hide();
            работа.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Бассейн2_п_оcs бассейн2_П_Оcs = new Бассейн2_п_оcs();
            this.Hide();
            бассейн2_П_Оcs.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._4);

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
