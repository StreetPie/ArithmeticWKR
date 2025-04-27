using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Сложные : Form
    {
        public Сложные()
        {
            InitializeComponent();
            ShowCurrentDate();
            labelUserName.Text = $"Пользователь: {
                .UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }
        private void ShowCurrentDate()
        {
            // Устанавливаем текущую дату в текстовое поле метки
            label1.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                Одно_направление одно_Направление = new Одно_направление();
                одно_Направление.Show();
            }
            // Добавьте условия для других форм, если необходимо

            // Закрываем текущую форму
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Сложность сложность = new Сложность();
            this.Hide();
            сложность.ShowDialog();
        }

        private void Сложные_Load(object sender, EventArgs e)
        {

        }
    }
}
