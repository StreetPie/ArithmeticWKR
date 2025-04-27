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
    public partial class Работа : Form
    {
        public Работа()
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
            if (radioButton1.Checked)
            {
                Бассейн бассейн = new Бассейн();
                this.Hide();
                бассейн.Show();
            }
            else if (radioButton2.Checked)
            {
                Вспашка вспашка = new Вспашка();
                this.Hide();
                вспашка.Show();
            }
            else if (radioButton3.Checked)
            {
                На_работу на_Работу = new На_работу();
                this.Hide();
                на_Работу.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Задачи задачи = new Задачи();
            this.Hide();
            задачи.ShowDialog();
        }

        private void Работа_Load(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
