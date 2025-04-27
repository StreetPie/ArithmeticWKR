using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Сложность : Form
    {
        public Сложность()
        {
            InitializeComponent();
            ShowCurrentDate();
            labelUserName.Text = $"Пользователь: {
                .UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }
        private void ShowCurrentDate()
        {
            // Устанавливаем текущую дату в текстовое поле метки
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Задачи задачи = new Задачи();
            this.Hide();
            задачи.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Легкие легкие = new Легкие();
                легкие.Show();
            }
            else if (radioButton2.Checked)
            {
                Средние средние = new Средние();
                средние.Show();
            }
            else if (radioButton3.Checked)
            {
                Сложные сложные = new Сложные();
                сложные.Show();
            }
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Сложность_Load(object sender, EventArgs e)
        {

        }
    }
}
