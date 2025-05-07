using Arithmetic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace Arithmetic.Forms
{
    partial class MainForm
    {
        private Label labelName;
        private Label labelSurname;
        private Label labelClass;
        private Button buttonBack;

        // Константы цветов
        private readonly Color BlueButtonColor = Color.DodgerBlue;
        private readonly Color BlueButtonHoverColor = Color.DeepSkyBlue;
        private readonly Color RedButtonColor = Color.IndianRed;
        private readonly Color RedButtonHoverColor = Color.FromArgb(220, 20, 60);
        private void InitializeComponent()
        {
            this.labelName = new Label();
            this.labelSurname = new Label();
            this.labelClass = new Label();
            this.buttonBack = new Button();

            // Настройка цветов
            int margin = 60;
            int buttonWidth = 250;
            int buttonHeight = 60;
            int labelBottomMargin = 30;

            // Label
            labelName.AutoSize = true;
            labelSurname.AutoSize = true;
            labelClass.AutoSize = true;

            Font labelFont = new Font("Segoe UI", 16F, FontStyle.Bold);
            Color labelColor = Color.Black;

            labelName.Font = labelFont;
            labelSurname.Font = labelFont;
            labelClass.Font = labelFont;

            labelName.ForeColor = labelColor;
            labelSurname.ForeColor = labelColor;
            labelClass.ForeColor = labelColor;
            

            // Button "Назад"
            buttonBack.Text = "Назад";
            buttonBack.Size = new Size(buttonWidth, buttonHeight);
            buttonBack.BackColor = RedButtonColor;
            buttonBack.ForeColor = Color.White;
            buttonBack.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.FlatAppearance.BorderSize = 0;

            Label labelSmallTitle = new Label
            {
                Text = "СИРС. Математика. Дроби.",
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point((this.ClientSize.Width - 250) / 2, 20)
            };

            Label labelMainTitle = new Label
            {
                Text = "Главное окно",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Location = new Point((this.ClientSize.Width - 300) / 2, 60)
            };

            Button buttonIndependent = new Button
            {
                Text = "Самостоятельная\nработа",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                Size = new Size(400, 90),
                ForeColor = Color.White,
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - 400) / 2, 300),
                BackColor = BlueButtonColor,
                FlatStyle = FlatStyle.Flat
            };

            Button buttonClassWork = new Button
            {
                Text = "Классная работа",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
               Size = new Size(400, 90),
             Location = new Point((Screen.PrimaryScreen.Bounds.Width - 400) / 2, 420),
             BackColor = BlueButtonColor,
               ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            Button buttonProfile = new Button
            {
                Text = "Профиль",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                Size = new Size(400, 90),
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - 400) / 2, 540),
                BackColor = RedButtonColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            // Добавление элементов
            this.Controls.Add(labelName);
            this.Controls.Add(labelSurname);
            this.Controls.Add(labelClass);
            this.Controls.Add(buttonBack);
            this.Controls.Add(labelSmallTitle);
            this.Controls.Add(labelMainTitle);
            this.Controls.Add(buttonIndependent);
            this.Controls.Add(buttonClassWork);
            this.Controls.Add(buttonProfile);
            buttonBack.Click += buttonBack_Click;
            buttonBack.MouseEnter += buttonBack_MouseEnter;
            buttonBack.MouseLeave += buttonBack_MouseLeave;

            buttonIndependent.Click += (s, e) =>
            {
                var factory = Program.AppHost.Services.GetRequiredService<IFormFactory<IndependentWorkForm>>();
                var form = factory.Create();
                form.Show();
            };



            buttonClassWork.Click += (s, e) => {
                var factory = Program.AppHost.Services.GetRequiredService<IFormFactory<ClassWorkForm>>();
                var form = factory.Create();
                form.Show();
            };


            buttonProfile.Click += (s, e) =>
            {
                var factory = Program.AppHost.Services.GetRequiredService<IFormFactory<StudentProfileForm>>();
                var form = factory.Create();
                form.Show();
            };

            void RepositionMainButtons()
            {
                int centerX = (this.ClientSize.Width - buttonIndependent.Width) / 2;
                int startY = 150;
                int spacing = 20;

                labelSmallTitle.Location = new Point((this.ClientSize.Width - labelSmallTitle.Width) / 2, 20);
                labelMainTitle.Location = new Point((this.ClientSize.Width - labelMainTitle.Width) / 2, 60);

                buttonIndependent.Location = new Point(centerX, startY);
                buttonClassWork.Location = new Point(centerX, startY + buttonIndependent.Height + spacing);
                buttonProfile.Location = new Point(centerX, startY + 2 * (buttonIndependent.Height + spacing));
            }

            this.Load += (s, e) => RepositionMainButtons();
            this.Resize += (s, e) => RepositionMainButtons();
            // Установка позиций при загрузке
            this.Load += (s, e) =>
            {
                buttonBack.Location = new Point(
                    this.ClientSize.Width - buttonWidth - margin,
                    this.ClientSize.Height - buttonHeight - margin
                );
                labelName.Location = new Point(40, this.ClientSize.Height - labelBottomMargin);
                labelSurname.Location = new Point(300, this.ClientSize.Height - labelBottomMargin);
                labelClass.Location = new Point(600, this.ClientSize.Height - labelBottomMargin);

            };

            // Обновление при ресайзе
            this.Resize += (s, e) =>
            {
                buttonBack.Location = new Point(
                    this.ClientSize.Width - buttonWidth - margin,
                    this.ClientSize.Height - buttonHeight - margin
                );

                labelName.Location = new Point(40, this.ClientSize.Height - labelBottomMargin);
                labelSurname.Location = new Point(300, this.ClientSize.Height - labelBottomMargin);
                labelClass.Location = new Point(600, this.ClientSize.Height - labelBottomMargin);

            };
        }


    }
}
