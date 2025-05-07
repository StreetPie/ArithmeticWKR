namespace Arithmetic.Forms
{
    partial class ExitConfirmationForm
    {

        private void InitializeComponent(string message)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(400, 200);
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.Opacity = 0;

            var label = new Label()
            {
                Text = message,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

            var buttonYes = new Button()
            {
                Text = "Да",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                BackColor = Color.LightCoral,
                ForeColor = Color.White,
                Size = new Size(130, 50),
                Location = new Point(60, 120)
            };
            buttonYes.Click += (s, e) => { Confirmed = true; this.Close(); };

            var buttonNo = new Button()
            {
                Text = "Нет",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                BackColor = Color.DeepSkyBlue,
                ForeColor = Color.White,
                Size = new Size(130, 50),
                Location = new Point(210, 120)
            };
            buttonNo.Click += (s, e) => { Confirmed = false; this.Close(); };

            this.Controls.Add(label);
            this.Controls.Add(buttonYes);
            this.Controls.Add(buttonNo);

            this.Paint += ExitConfirmationForm_Paint;
        }
    }
    }