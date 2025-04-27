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
    public partial class Встречное_движение2_п_о : Form
    {
        public Встречное_движение2_п_о()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Встречное_движение2 встречное_Движение2 = new Встречное_движение2();
            this.Hide();
            встречное_Движение2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources._13);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }

        private void Встречное_движение2_п_о_Load(object sender, EventArgs e)
        {

        }
    }
}
