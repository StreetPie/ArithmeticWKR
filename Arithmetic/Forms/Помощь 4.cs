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
    public partial class Помощь_4 : Form
    {
        public Помощь_4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            На_работу на_Работу = new На_работу();
            this.Hide();
            на_Работу.ShowDialog();
        }
    }
}
