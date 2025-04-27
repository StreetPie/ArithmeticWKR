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
    public partial class Урок_3_п : Form
    {
        public Урок_3_п()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            урок_3 урок_3 = new урок_3();
            this.Hide();
            урок_3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._36);
            // Load the sound
            ss.Load();
            // Play the sound synchronously
            ss.PlaySync();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
