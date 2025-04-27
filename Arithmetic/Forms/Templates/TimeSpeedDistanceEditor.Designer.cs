namespace Arithmetic.Forms.Templates
{
    partial class TimeSpeedDistanceEditor
    {
        private NumericUpDown numericUpDownSpeed;
        private NumericUpDown numericUpDownDistance;
        private Label labelSpeed;
        private Label labelDistance;
        private RichTextBox richTextBoxPreview;
        private ComboBox comboBoxDifficulty;
        private Button buttonRandomImage;
        private Button buttonSave;
        private Button buttonCancel;
        private Button buttonExit;
        private Label labelAnswer;
        private Button buttonAddAudio;
        private PictureBox pictureBoxBear;
        private Button buttonSaveTask;
        private Button buttonExitConstructor;
        private Button buttonOpenAudioSite;
        private CheckBox checkBoxHasAudio;


        private void InitializeComponent()
        {
            buttonSaveTask = new Button();
            buttonExitConstructor = new Button();
            buttonOpenAudioSite = new Button();
            numericUpDownSpeed = new NumericUpDown();
            numericUpDownDistance = new NumericUpDown();
            labelSpeed = new Label();
            labelDistance = new Label();
            richTextBoxPreview = new RichTextBox();
            comboBoxDifficulty = new ComboBox();
            buttonRandomImage = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            buttonExit = new Button();
            labelAnswer = new Label();
            buttonAddAudio = new Button();
            pictureBoxBear = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBear).BeginInit();
            SuspendLayout();

            //
            this.checkBoxHasAudio = new CheckBox();
            this.checkBoxHasAudio.Font = new Font("Segoe UI", 18F);
            this.checkBoxHasAudio.Location = new Point(1200, 510); // Рядом с кнопкой аудио
            this.checkBoxHasAudio.Size = new Size(250, 40);
            this.checkBoxHasAudio.Text = "Есть аудио";
            this.checkBoxHasAudio.Checked = false;

            this.Controls.Add(this.checkBoxHasAudio);

            // 
            // buttonOpenAudioSite
            // 
            buttonOpenAudioSite.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            buttonOpenAudioSite.Location = new Point(800, 500);
            buttonOpenAudioSite.Name = "buttonOpenAudioSite";
            buttonOpenAudioSite.Size = new Size(350, 50);
            buttonOpenAudioSite.TabIndex = 0;
            buttonOpenAudioSite.Text = "Добавить аудио";
            buttonOpenAudioSite.Click += buttonOpenAudioSite_Click;
            // 
            // numericUpDownSpeed
            // 
            numericUpDownSpeed.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            numericUpDownSpeed.Location = new Point(400, 50);
            numericUpDownSpeed.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownSpeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSpeed.Name = "numericUpDownSpeed";
            numericUpDownSpeed.Size = new Size(200, 50);
            numericUpDownSpeed.TabIndex = 0;
            numericUpDownSpeed.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownSpeed.ValueChanged += NumericUpDown_ValueChanged;
            // 
            // numericUpDownDistance
            // 
            numericUpDownDistance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            numericUpDownDistance.Location = new Point(400, 150);
            numericUpDownDistance.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownDistance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDistance.Name = "numericUpDownDistance";
            numericUpDownDistance.Size = new Size(200, 50);
            numericUpDownDistance.TabIndex = 1;
            numericUpDownDistance.Value = new decimal(new int[] { 40, 0, 0, 0 });
            numericUpDownDistance.ValueChanged += NumericUpDown_ValueChanged;
            // 
            // labelSpeed
            // 
            labelSpeed.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelSpeed.Location = new Point(50, 50);
            labelSpeed.Name = "labelSpeed";
            labelSpeed.Size = new Size(300, 50);
            labelSpeed.TabIndex = 2;
            labelSpeed.Text = "Скорость (км/ч):";
            // 
            // labelDistance
            // 
            labelDistance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelDistance.Location = new Point(50, 150);
            labelDistance.Name = "labelDistance";
            labelDistance.Size = new Size(300, 50);
            labelDistance.TabIndex = 3;
            labelDistance.Text = "Расстояние (км):";
            // 
            // richTextBoxPreview
            // 
            richTextBoxPreview.Font = new Font("Segoe UI", 20F);
            richTextBoxPreview.Location = new Point(50, 250);
            richTextBoxPreview.Name = "richTextBoxPreview";
            richTextBoxPreview.ReadOnly = true;
            richTextBoxPreview.Size = new Size(800, 150);
            richTextBoxPreview.TabIndex = 4;
            richTextBoxPreview.Text = "";
            // 
            // comboBoxDifficulty
            // 
            comboBoxDifficulty.Font = new Font("Segoe UI", 20F);
            comboBoxDifficulty.Items.AddRange(new object[] { "Лёгкая", "Средняя", "Сложная" });
            comboBoxDifficulty.Location = new Point(50, 500);
            comboBoxDifficulty.Name = "comboBoxDifficulty";
            comboBoxDifficulty.Size = new Size(300, 45);
            comboBoxDifficulty.TabIndex = 6;
            // 
            // buttonRandomImage
            // 
            buttonRandomImage.Font = new Font("Segoe UI", 20F);
            buttonRandomImage.Location = new Point(400, 500);
            buttonRandomImage.Name = "buttonRandomImage";
            buttonRandomImage.Size = new Size(350, 50);
            buttonRandomImage.TabIndex = 7;
            buttonRandomImage.Text = "Случайная картинка";
            buttonRandomImage.Click += buttonRandomImage_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            buttonSave.Location = new Point(21, 700);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(400, 80);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            buttonCancel.Location = new Point(455, 700);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(242, 80);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отменить";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonExit
            // 
            buttonExit.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            buttonExit.Location = new Point(732, 700);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(400, 80);
            buttonExit.TabIndex = 12;
            buttonExit.Text = "Выйти из конструктора";
            buttonExit.Click += buttonExit_Click;
            // 
            // labelAnswer
            // 
            labelAnswer.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelAnswer.Location = new Point(50, 420);
            labelAnswer.Name = "labelAnswer";
            labelAnswer.Size = new Size(600, 50);
            labelAnswer.TabIndex = 5;
            labelAnswer.Text = "Ответ:";
            // 
            // buttonAddAudio
            // 
            buttonAddAudio.Font = new Font("Segoe UI", 20F);
            buttonAddAudio.Location = new Point(800, 500);
            buttonAddAudio.Name = "buttonAddAudio";
            buttonAddAudio.Size = new Size(350, 50);
            buttonAddAudio.TabIndex = 8;
            buttonAddAudio.Text = "Добавить аудио";
            buttonAddAudio.Click += buttonOpenAudioSite_Click;
            // 
            // pictureBoxBear
            // 
            pictureBoxBear.Location = new Point(900, 50);
            pictureBoxBear.Name = "pictureBoxBear";
            pictureBoxBear.Size = new Size(900, 600);
            pictureBoxBear.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBear.TabIndex = 9;
            pictureBoxBear.TabStop = false;
            // 
            // TimeSpeedDistanceEditor
            // 
            Controls.Add(numericUpDownSpeed);
            Controls.Add(numericUpDownDistance);
            Controls.Add(labelSpeed);
            Controls.Add(labelDistance);
            Controls.Add(richTextBoxPreview);
            Controls.Add(labelAnswer);
            Controls.Add(comboBoxDifficulty);
            Controls.Add(buttonRandomImage);
            Controls.Add(buttonAddAudio);
            Controls.Add(pictureBoxBear);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Controls.Add(buttonExit);
            Name = "TimeSpeedDistanceEditor";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)numericUpDownSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBear).EndInit();
            ResumeLayout(false);
            UpdatePreview();
        }
    }
}
