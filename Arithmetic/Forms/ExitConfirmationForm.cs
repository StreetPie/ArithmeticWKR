using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Arithmetic.Forms
{
    public partial class ExitConfirmationForm : Form
    {
        public bool Confirmed { get; private set; } = false;

        public ExitConfirmationForm()
        {
            InitializeComponent();
            FadeInEffect();
        }

      

        private void ExitConfirmationForm_Paint(object sender, PaintEventArgs e)
        {
            // Рисуем скругленные углы
            var bounds = this.ClientRectangle;
            bounds.Inflate(-1, -1);
            var radius = 30;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private async void FadeInEffect()
        {
            for (double i = 0; i <= 1; i += 0.05)
            {
                await Task.Delay(15);
                this.Opacity = i;
            }
        }
    }
}
