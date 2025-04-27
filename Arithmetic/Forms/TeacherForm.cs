using System;
using System.Windows.Forms;
using Arithmetic.Forms; // Подключаем формы
using Arithmetic.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Arithmetic.Forms
{
    public partial class TeacherForm : Form
    {
        private readonly AppDbContext _dbContext;

        public TeacherForm(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;

            LoadTasks(); // загрузить список задач
        }

        private void LoadTasks()
        {
            var tasks = _dbContext.SchoolTasks
                .Select(t => new
                {
                    t.Id,
                    t.Text,
                    Difficulty = t.Difficulty == 0 ? "Лёгкая" : (t.Difficulty == 1 ? "Средняя" : "Сложная"),
                    t.HasAudio
                })
                .ToList();

            dataGridViewTasks.DataSource = tasks;
        }

        private void buttonTaskConstructor_Click(object sender, EventArgs e)
        {
            var form = new TaskConstructorForm();
            form.ShowDialog();
        }
        private void buttonStudentsList_Click(object sender, EventArgs e)
        {
            var studentsForm = Program.AppHost.Services.GetRequiredService<StudentsListForm>();
            studentsForm.ShowDialog();
        }


        private void buttonProgress_Click(object sender, EventArgs e)
        {
            var studentsForm = Program.AppHost.Services.GetRequiredService<StudentsListForm>();
            studentsForm.ShowDialog();
        }
    }
}
