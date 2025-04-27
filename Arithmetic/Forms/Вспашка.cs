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
    public partial class Вспашка : Form
    {
        private const string CorrectAnswer = "12/35";
        public Вспашка()
        {
            InitializeComponent();
            button4.Enabled = false;
            labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли правильный вариант ответа
            if (radioButton1.Checked && radioButton1.Text == CorrectAnswer)
            {
                MessageBox.Show("Правильный ответ!");
                Вспашка2 вспашка2 = new Вспашка2();
                this.Hide();
                вспашка2.ShowDialog();
            }
            else if (radioButton2.Checked && radioButton2.Text == CorrectAnswer)
            {
                MessageBox.Show("Правильный ответ!");
            }
            else if (radioButton3.Checked && radioButton3.Text == CorrectAnswer)
            {
                MessageBox.Show("Правильный ответ!");
   
            }
            else if (radioButton4.Checked && radioButton4.Text == CorrectAnswer)
            {
                MessageBox.Show("Правильный ответ!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Неправильный ответ. Хотите посмотреть решение?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // Если пользователь выбрал "Да", показываем решение
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Enabled = true; // Разблокируем кнопку "Помощь"
                    Вспашка_п вспашка_П = new Вспашка_п();
                    this.Hide();
                    вспашка_П.ShowDialog();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Вспашка_п вспашка_П = new Вспашка_п();
            this.Hide();
            вспашка_П.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._8);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }

        private void Вспашка_Load(object sender, EventArgs e)
        {

        }
    }
}
