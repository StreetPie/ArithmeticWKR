using System.Windows.Forms;

namespace Arithmetic.Forms
{
    partial class TeacherForm
    {
        private Button buttonTaskConstructor;
        private Button buttonStudents;
        private Button buttonProgress;
        private DataGridView dataGridViewTasks;
        private Button buttonBack;


        // Константы цветов
        private readonly Color BlueButtonColor = Color.DodgerBlue;
        private readonly Color BlueButtonHoverColor = Color.DeepSkyBlue;
        private readonly Color RedButtonColor = Color.IndianRed;
        private readonly Color RedButtonHoverColor = Color.FromArgb(220, 20, 60);
        private void InitializeComponent()
        {
            buttonTaskConstructor = new Button();
            buttonStudents = new Button();
            buttonProgress = new Button();
            dataGridViewTasks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).BeginInit();
            SuspendLayout();
            // 
            // buttonTaskConstructor
            // 
            buttonTaskConstructor.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            buttonTaskConstructor.Location = new Point(50, 30);
            buttonTaskConstructor.Name = "buttonTaskConstructor";
            buttonTaskConstructor.Size = new Size(500, 80);
            buttonTaskConstructor.TabIndex = 0;
            buttonTaskConstructor.Text = "Конструктор задач";
            buttonTaskConstructor.Click += buttonTaskConstructor_Click;
            // 
            // buttonStudents
            // 
            buttonStudents.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            buttonStudents.Location = new Point(600, 30);
            buttonStudents.Name = "buttonStudents";
            buttonStudents.Size = new Size(500, 80);
            buttonStudents.TabIndex = 1;
            buttonStudents.Text = "Список учеников";
            buttonStudents.Click += buttonStudentsList_Click;
            // 
            // buttonProgress
            // 
            buttonProgress.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            buttonProgress.Location = new Point(1150, 30);
            buttonProgress.Name = "buttonProgress";
            buttonProgress.Size = new Size(500, 80);
            buttonProgress.TabIndex = 2;
            buttonProgress.Text = "График успеваемости";
            buttonProgress.Click += buttonProgress_Click;
            // 
            // dataGridViewTasks
            // 
            dataGridViewTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewTasks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
           // dataGridViewTasks.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
            dataGridViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; 
            dataGridViewTasks.RowTemplate.Height = 50;
            dataGridViewTasks.Font = new Font("Segoe UI", 16F);
            dataGridViewTasks.Location = new Point(50, 150);
            dataGridViewTasks.Size = new Size(1800, 671);
            dataGridViewTasks.TabIndex = 3;
            dataGridViewTasks.CellContentClick += dataGridViewTasks_CellContentClick;


            // Button "Назад"
            buttonBack = new Button();
            buttonBack.Text = "Назад";
            buttonBack.Size = new Size(200, 60);
            buttonBack.BackColor = RedButtonColor;
            buttonBack.ForeColor = Color.White;
            buttonBack.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.FlatAppearance.BorderSize = 0;


            // 
            // TeacherForm
            // 
            ClientSize = new Size(1920, 1061);
            Controls.Add(buttonTaskConstructor);
            Controls.Add(buttonStudents);
            Controls.Add(buttonProgress);
            Controls.Add(dataGridViewTasks);
            this.Controls.Add(buttonBack);
            buttonBack.Click += buttonBack_Click;
            buttonBack.MouseEnter += buttonBack_MouseEnter;
            buttonBack.MouseLeave += buttonBack_MouseLeave;
            // Правый нижний угол почти вплотную
            buttonBack.Location = new Point(ClientSize.Width - buttonBack.Width - 30, ClientSize.Height - buttonBack.Height - 30);
            buttonBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            Name = "TeacherForm";
            Text = "Панель учителя";


            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).EndInit();
            ResumeLayout(false);
        }
    }
}
