using System;
using System.Windows.Forms;
using Arithmetic.Forms; 
using Arithmetic.Database;
using Microsoft.Extensions.DependencyInjection;
using Arithmetic.Forms.Templates;
using Microsoft.EntityFrameworkCore;
using Arithmetic.Services;

namespace Arithmetic.Forms
{
    public partial class TeacherForm : Form
    {
        private readonly AppDbContext _dbContext;
        //private readonly IServiceScopeFactory _scopeFactory;


        public TeacherForm(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            BlurService.EnableBlur(this);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            LoadTasks(); 
        }
        private Dictionary<int, string> taskImages = new Dictionary<int, string>();

        private void LoadTasks()
        {
            var tasks = _dbContext.SchoolTasks
                .Select(t => new
                {
                    t.Id,
                    t.Text,
                    Difficulty = t.Difficulty == 0 ? "Лёгкая" : (t.Difficulty == 1 ? "Средняя" : "Сложная"),
                    t.Answer,
                    t.HasAudio,
                    t.HasImage
                })
                .ToList();

            dataGridViewTasks.DataSource = tasks;

            if (dataGridViewTasks.Columns.Contains("SelectedImagePath"))
            {
                var colIndex = dataGridViewTasks.Columns["SelectedImagePath"].Index;
                dataGridViewTasks.Columns.Remove("SelectedImagePath");

                var imageCol = new DataGridViewImageColumn();
                imageCol.Name = "Image";
                imageCol.HeaderText = "Картинка";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 50; 

                dataGridViewTasks.Columns.Insert(colIndex, imageCol);

                dataGridViewTasks.Columns.Clear(); 

                dataGridViewTasks.DataSource = tasks;

               // taskImages.Clear();
                //foreach (var task in tasks)
              //  {
                 //   if (task.HasImage)
                  //  {
                        // Загружаешь путь к картинке по task.Id
                    //    var imagePath = GetImagePathForTask(task.Id);
                      //  if (!string.IsNullOrEmpty(imagePath))
                        //    taskImages[task.Id] = imagePath;
                 //   }
                //}



                dataGridViewTasks.Columns.Insert(2, imageCol); 

                foreach (DataGridViewRow row in dataGridViewTasks.Rows)
                {
                    if (row.IsNewRow) continue;

                    int taskId = Convert.ToInt32(row.Cells["Id"].Value);
                    if (taskImages.TryGetValue(taskId, out string imagePath) && File.Exists(imagePath))
                    {
                        row.Cells["ImagePreview"].Value = LoadSmallImage(imagePath, 32, 32);
                    }
                }

                dataGridViewTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Только один режим!
            }
        }

private Image LoadSmallImage(string path, int width, int height)
        {
            using (var img = Image.FromFile(path))
            {
                return new Bitmap(img, new Size(width, height));
            }
        }
        private void dataGridViewTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewTasks.Columns[e.ColumnIndex].Name == "ImagePreview")
            {
                int taskId = Convert.ToInt32(dataGridViewTasks.Rows[e.RowIndex].Cells["Id"].Value);

                if (taskImages.TryGetValue(taskId, out string imagePath) && File.Exists(imagePath))
                {
                    var form = new Form();
                    form.Text = "Просмотр картинки";
                    form.Width = 600;
                    form.Height = 600;

                    var pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = Image.FromFile(imagePath);

                    form.Controls.Add(pictureBox);
                    form.ShowDialog();
                }
            }
        }

        private void buttonTaskConstructor_Click(object sender, EventArgs e)
        {
            var form = new TaskConstructorForm();
            form.ShowDialog();
        }
        private void buttonStudentsList_Click(object sender, EventArgs e)
        {
            using (var scope = Program.AppHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var studentsForm = services.GetRequiredService<StudentsListForm>();
                studentsForm.ShowDialog();
            }
        }
        private void buttonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonHoverColor;
        }

        private void buttonBack_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonColor;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            using (var confirmationForm = new ExitConfirmationForm("Вы точно хотите выйти из профиля?"))
            {
                confirmationForm.ShowDialog();

                if (confirmationForm.Confirmed)
                {
                    var loginForm = Program.AppHost.Services.GetRequiredService<LoginForm>();
                    loginForm.Show();
                    this.Close();
                }
            }
        }


        private void buttonProgress_Click(object sender, EventArgs e)
        {
            var studentsForm = Program.AppHost.Services.GetRequiredService<StudentsListForm>();
            studentsForm.ShowDialog();
        }

        private void dataGridViewTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
