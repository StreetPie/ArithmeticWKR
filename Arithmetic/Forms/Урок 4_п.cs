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
    public partial class Урок_4_п : Form
    {
        public Урок_4_п()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._38);
            // Load the sound
            ss.Load();
            // Play the sound synchronously
            ss.PlaySync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Урок_4 урок_4 = new Урок_4();
            this.Hide();
            урок_4.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
