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
    public partial class Form2 : Form
    {
        private string firstName;
        private string lastName;
        public Form2()
        {
            InitializeComponent();
            labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {AuthInfo.UserSurname}";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Главное_окно главное_Окно = new Главное_окно();
            this.Hide();
            главное_Окно.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Урок_1 урок_1 = new Урок_1();
            this.Hide();
            урок_1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Урок_2 урок_2 = new Урок_2();
            this.Hide();
            урок_2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            урок_3 урок_3 = new урок_3();
            this.Hide();
            урок_3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Урок_4 урок_4 = new Урок_4();
            this.Hide();
            урок_4.ShowDialog();
        }
    }
}
