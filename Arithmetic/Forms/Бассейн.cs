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
    public partial class Бассейн : Form
    {
        // Правильный ответ
        private const string CorrectAnswer = "5/36";
        public Бассейн()
        {
            InitializeComponent();
            button4.Enabled = false; // Изначально кнопка заблокирована
          //  labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли правильный вариант ответа
            if (radioButton1.Checked && radioButton1.Text == CorrectAnswer)
            {
                MessageBox.Show("Правильный ответ!");
            }
            else if (radioButton2.Checked && radioButton2.Text == CorrectAnswer)
            {
                MessageBox.Show("Правильный ответ!");

            }
            else if (radioButton3.Checked && radioButton3.Text == CorrectAnswer)
            {
                MessageBox.Show("Правильный ответ!");
                Бассейн2 бассейн2 = new Бассейн2();
                this.Hide();
                бассейн2.ShowDialog();
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
                    Бассейн_п_о бассейн_П_О = new Бассейн_п_о();
                    this.Hide();
                    бассейн_П_О.ShowDialog();
                }
                else
                {
                    button4.Enabled = false; // Блокируем кнопку "Помощь"
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Работа работа = new Работа();
            this.Hide();
            работа.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Бассейн_п_о бассейн_П_О = new Бассейн_п_о();
            this.Hide();
            бассейн_П_О.ShowDialog();
        }

        private void Бассейн_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._2);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }
    }
}
