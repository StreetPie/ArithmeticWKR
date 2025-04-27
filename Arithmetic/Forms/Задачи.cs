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
    public partial class Задачи : Form
    {
        public Задачи()
        {
            InitializeComponent();
            ShowCurrentDate();
            labelUserName.Text = $"Пользователь: {
                .UserName} {AuthInfo.UserSurname}";
        }
        private void ShowCurrentDate()
        {
            // Устанавливаем текущую дату в текстовое поле метки
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Главное_окно главное_Окно = new Главное_окно();
            this.Hide();
            главное_Окно.ShowDialog();

        }
        private void Задачи_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Сложность сложность = new Сложность();
            this.Hide();
            сложность.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Работа работа = new Работа();
            this.Hide();
            работа.ShowDialog();
        }
    }
}
