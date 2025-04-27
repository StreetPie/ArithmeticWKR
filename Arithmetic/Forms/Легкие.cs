using System;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Легкие : Form
    {
        public Легкие()
        {
            InitializeComponent();
            ShowCurrentDate();
            labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }
        private void ShowCurrentDate()
        {
            // Устанавливаем текущую дату в текстовое поле метки
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Скорость скорость = new Скорость();
                скорость.Show();
            }
            else if (radioButton1.Checked)
            {
                Время время = new Время();
                время.Show();
            }
            else if (radioButton3.Checked)
            {
                Расстояние расстояние = new Расстояние();
                расстояние.Show();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Сложность сложность = new Сложность();
            this.Hide();
            сложность.ShowDialog();
        }

        private void Легкие_Load(object sender, EventArgs e)
        {

        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
