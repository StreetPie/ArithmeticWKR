namespace Arithmetic.Forms
{
    partial class ClassWorkForm
    {
        private Button buttonBack;

        // Цвета
        private readonly Color RedButtonColor = Color.IndianRed;
        private readonly Color RedButtonHoverColor = Color.FromArgb(220, 20, 60);
        private Label labelName;
        private Label labelSurname;
        private Label labelClass;
        private void InitializeComponent()
        {
            this.buttonBack = new Button();

            richTextChapters = new RichTextBox
            {
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 14F),
                BackColor = Color.White,
                ForeColor = Color.Black,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Size = new Size(600, 500)
            };
            this.Controls.Add(richTextChapters);



            this.Controls.Add(richTextChapters);


            this.Controls.Add(richTextChapters);

            // Заголовки
            Label labelSmallTitle = new Label
            {
                Text = "СИРС. Математика. Дроби.",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            Label labelMainTitle = new Label
            {
                Text = "Классная работа",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            // Кнопка "Назад"
            buttonBack.Text = "Назад";
            buttonBack.Size = new Size(250, 60);
            buttonBack.BackColor = RedButtonColor;
            buttonBack.ForeColor = Color.White;
            buttonBack.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.FlatAppearance.BorderSize = 0;

            this.labelName = new Label();
            this.labelSurname = new Label();
            this.labelClass = new Label();
            Font labelFont = new Font("Segoe UI", 16F, FontStyle.Bold);
            Color labelColor = Color.Black;

            labelName.Font = labelFont;
            labelSurname.Font = labelFont;
            labelClass.Font = labelFont;

            labelName.ForeColor = labelColor;
            labelSurname.ForeColor = labelColor;
            labelClass.ForeColor = labelColor;

            labelName.AutoSize = true;
            labelSurname.AutoSize = true;
            labelClass.AutoSize = true;


            int labelBottomMargin = 30;
            this.Load += (s, e) =>
            {
                labelName.Location = new Point(40, this.ClientSize.Height - labelBottomMargin);
                labelSurname.Location = new Point(300, this.ClientSize.Height - labelBottomMargin);
                labelClass.Location = new Point(600, this.ClientSize.Height - labelBottomMargin);
            };

            this.Resize += (s, e) =>
            {
                labelName.Location = new Point(40, this.ClientSize.Height - labelBottomMargin);
                labelSurname.Location = new Point(300, this.ClientSize.Height - labelBottomMargin);
                labelClass.Location = new Point(600, this.ClientSize.Height - labelBottomMargin);
            };

            this.Controls.Add(labelName);
            this.Controls.Add(labelSurname);
            this.Controls.Add(labelClass);
            this.Controls.Add(labelSmallTitle);
            this.Controls.Add(labelMainTitle);
            this.Controls.Add(buttonBack);

            // События
            buttonBack.Click += buttonBack_Click;
            buttonBack.MouseEnter += buttonBack_MouseEnter;
            buttonBack.MouseLeave += buttonBack_MouseLeave;

            // Расположение элементов
            void Reposition()
            {
                int centerX = (this.ClientSize.Width - 400) / 2;

                labelSmallTitle.Location = new Point((this.ClientSize.Width - labelSmallTitle.Width) / 2, 20);
                labelMainTitle.Location = new Point((this.ClientSize.Width - labelMainTitle.Width) / 2, 60);

                buttonBack.Location = new Point(
                    this.ClientSize.Width - buttonBack.Width - 60,
                    this.ClientSize.Height - buttonBack.Height - 60
                );
            }
            this.Load += (s, e) =>
            {
                Reposition();
                LoadUserInfo();

                int topOffset = labelMainTitle.Bottom + 30;
                richTextChapters.Location = new Point(40, topOffset);
            };

            this.Resize += (s, e) =>
            {
                Reposition();

                int topOffset = labelMainTitle.Bottom + 30;
                richTextChapters.Location = new Point(40, topOffset);
            };
        }
    }
}
