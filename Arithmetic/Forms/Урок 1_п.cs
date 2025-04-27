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
    public partial class Урок_1_п : Form
    {
        public Урок_1_п()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Урок_1 урок_1 = new Урок_1();
            this.Hide();
            урок_1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._30);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
