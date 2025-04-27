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
    public partial class Вспашка2_п_о : Form
    {
        public Вспашка2_п_о()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Вспашка2 вспашка2 = new Вспашка2();
            this.Hide();
            вспашка2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._9);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }
    }
}
