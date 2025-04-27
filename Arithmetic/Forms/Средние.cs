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
    public partial class Средние : Form
    {
        public Средние()
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
             if (radioButton4.Checked)
            {
                Встречное_движение встречное_Движение = new Встречное_движение();
                встречное_Движение.Show();
            }
            else if (radioButton5.Checked)
            {
                Противоположные_направления противоположные_Направления = new Противоположные_направления();
                противоположные_Направления.Show();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Сложность сложность = new Сложность();
            this.Hide();
            сложность.ShowDialog();
        }

        private void Средние_Load(object sender, EventArgs e)
        {

        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
