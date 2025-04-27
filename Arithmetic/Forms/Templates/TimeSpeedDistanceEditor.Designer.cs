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


        private void InitializeComponent()
        {
            // Кнопка Сохранить
this.buttonSaveTask = new Button();
this.buttonSaveTask.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
this.buttonSaveTask.Location = new System.Drawing.Point(50, 900);
this.buttonSaveTask.Size = new System.Drawing.Size(400, 80);
this.buttonSaveTask.Text = "Сохранить";
this.buttonSaveTask.Click += new EventHandler(this.buttonSaveTask_Click);

// Кнопка Выход
this.buttonExitConstructor = new Button();
this.buttonExitConstructor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
this.buttonExitConstructor.Location = new System.Drawing.Point(500, 900);
this.buttonExitConstructor.Size = new System.Drawing.Size(400, 80);
this.buttonExitConstructor.Text = "Выход";
this.buttonExitConstructor.Click += new EventHandler(this.buttonExitConstructor_Click);

// Кнопка Добавить Аудио
this.buttonOpenAudioSite = new Button();
this.buttonOpenAudioSite.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
this.buttonOpenAudioSite.Location = new System.Drawing.Point(800, 500);
this.buttonOpenAudioSite.Size = new System.Drawing.Size(350, 50);
this.buttonOpenAudioSite.Text = "Добавить аудио";
this.buttonOpenAudioSite.Click += new EventHandler(this.buttonOpenAudioSite_Click);



            this.numericUpDownSpeed = new NumericUpDown();
            this.numericUpDownDistance = new NumericUpDown();
            this.labelSpeed = new Label();
            this.labelDistance = new Label();
            this.richTextBoxPreview = new RichTextBox();
            this.comboBoxDifficulty = new ComboBox();
            this.buttonRandomImage = new Button();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            this.buttonExit = new Button();
            this.labelAnswer = new Label();
            this.buttonAddAudio = new Button();
            this.pictureBoxBear = new PictureBox();

// Заменить текст на кнопке рандомной картинки:
this.buttonRandomImage.Text = "Случайное фото";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBear)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.numericUpDownSpeed.Location = new System.Drawing.Point(400, 50);
            this.numericUpDownSpeed.Maximum = 1000;
            this.numericUpDownSpeed.Minimum = 1;
            this.numericUpDownSpeed.Value = 10;
            this.numericUpDownSpeed.Size = new System.Drawing.Size(200, 55);
            this.numericUpDownSpeed.ValueChanged += (s, e) => UpdatePreview();
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.numericUpDownDistance.Location = new System.Drawing.Point(400, 150);
            this.numericUpDownDistance.Maximum = 10000;
            this.numericUpDownDistance.Minimum = 1;
            this.numericUpDownDistance.Value = 40;
            this.numericUpDownDistance.Size = new System.Drawing.Size(200, 55);
            this.numericUpDownDistance.ValueChanged += (s, e) => UpdatePreview();
            // 
            // labelSpeed
            // 
            this.labelSpeed.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.labelSpeed.Location = new System.Drawing.Point(50, 50);
            this.labelSpeed.Size = new System.Drawing.Size(300, 50);
            this.labelSpeed.Text = "Скорость (км/ч):";
            // 
            // labelDistance
            // 
            this.labelDistance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.labelDistance.Location = new System.Drawing.Point(50, 150);
            this.labelDistance.Size = new System.Drawing.Size(300, 50);
            this.labelDistance.Text = "Расстояние (км):";
            // 
            // richTextBoxPreview
            // 
            this.richTextBoxPreview.Font = new Font("Segoe UI", 20F);
            this.richTextBoxPreview.Location = new System.Drawing.Point(50, 250);
            this.richTextBoxPreview.Size = new System.Drawing.Size(800, 150);
            this.richTextBoxPreview.ReadOnly = true;
            // 
            // labelAnswer
            // 
            this.labelAnswer.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.labelAnswer.Location = new System.Drawing.Point(50, 420);
            this.labelAnswer.Size = new System.Drawing.Size(600, 50);
            this.labelAnswer.Text = "Ответ:";
            // 
            // comboBoxDifficulty
            // 
            this.comboBoxDifficulty.Font = new Font("Segoe UI", 20F);
            this.comboBoxDifficulty.Location = new System.Drawing.Point(50, 500);
            this.comboBoxDifficulty.Size = new System.Drawing.Size(300, 50);
            this.comboBoxDifficulty.Items.AddRange(new object[] { "Лёгкая", "Средняя", "Сложная" });
            // 
            // buttonRandomImage
            // 
            this.buttonRandomImage.Font = new Font("Segoe UI", 20F);
            this.buttonRandomImage.Location = new System.Drawing.Point(400, 500);
            this.buttonRandomImage.Size = new System.Drawing.Size(350, 50);
            this.buttonRandomImage.Text = "Случайный медведь";
            this.buttonRandomImage.Click += new EventHandler(this.buttonRandomImage_Click);
            // 
            // checkBoxAudio
            // 
            this.buttonAddAudio = new Button();
            this.buttonAddAudio.Font = new Font("Segoe UI", 20F);
            this.buttonAddAudio.Location = new System.Drawing.Point(800, 500);
            this.buttonAddAudio.Size = new System.Drawing.Size(350, 50);
            this.buttonAddAudio.Text = "Добавить аудио";
            this.buttonAddAudio.Click += new EventHandler(this.buttonOpenAudioSite_Click);

            // 
            // pictureBoxBear
            // 
            this.pictureBoxBear.Location = new System.Drawing.Point(900, 50);
            this.pictureBoxBear.Size = new System.Drawing.Size(900, 600);
            this.pictureBoxBear.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // buttonSave
            // 
            this.buttonSaveTask = new Button();
            this.buttonSaveTask.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.buttonSaveTask.Location = new Point(400, 600);
            this.buttonSaveTask.Size = new Size(400, 80);
            this.buttonSaveTask.Text = "Сохранить задачу";
            this.buttonSaveTask.Click += new EventHandler(this.buttonSaveTask_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.buttonCancel.Location = new System.Drawing.Point(500, 700);
            this.buttonCancel.Size = new System.Drawing.Size(400, 80);
            this.buttonCancel.Text = "Отменить";
            // 
            // buttonExit
            // 
            this.buttonExitConstructor = new Button();
            this.buttonExitConstructor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.buttonExitConstructor.Location = new Point(900, 600);
            this.buttonExitConstructor.Size = new Size(400, 80);
            this.buttonExitConstructor.Text = "Выйти из конструктора";
            this.buttonExitConstructor.Click += new EventHandler(this.buttonExitConstructor_Click);
            // 
            // TimeSpeedDistanceEditor
            // 
            this.Controls.Add(this.numericUpDownSpeed);
            this.Controls.Add(this.numericUpDownDistance);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.richTextBoxPreview);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.comboBoxDifficulty);
            this.Controls.Add(this.buttonRandomImage);
            this.Controls.Add(this.buttonAddAudio);
            this.Controls.Add(this.pictureBoxBear);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExit);
            this.Size = new System.Drawing.Size(1920, 1080);
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBear)).EndInit();

            UpdatePreview();
        }
    }
}
