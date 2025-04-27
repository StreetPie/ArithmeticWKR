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
    public partial class На_работу_п_о : Form
    {
        public На_работу_п_о()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            На_работу на_Работу = new На_работу();
            this.Hide();
            на_Работу.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._15);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }
    }
}
