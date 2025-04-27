using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using Arithmetic.Models;
using Arithmetic.Forms;

namespace Arithmetic
{
    public partial class Бассейн_п_о : Form
    {
        public Бассейн_п_о()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Бассейн бассейн = new Бассейн();
            this.Hide();
            бассейн.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ss = new SoundPlayer(Properties.Resources.бассейн_п_с);

            // Load the sound
            ss.Load();

            // Play the sound synchronously
            ss.PlaySync();
        }
    }
}
