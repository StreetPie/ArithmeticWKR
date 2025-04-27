using Arithmetic.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arithmetic.Forms
{
    public partial class StudentsListForm : Form
    {
        private readonly AppDbContext _dbContext;

        public StudentsListForm(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            LoadStudentsRating();
            ApplyColorByScore();
            ApplyMedals();
        }

        private void LoadStudentsRating()
        {
            var students = _dbContext.Users
                .Where(u => u.RoleId == 1)
                .ToList(); // Сначала забираем учеников

            var results = _dbContext.Results
                .AsEnumerable(); 

            var ratings = students
                .Select(user => new
                {
                    FullName = user.FirstName + " " + user.LastName,
                    AverageScore = results
                        .Where(r => r.StudentId == user.Id)
                        .Select(r => (double?)r.Score)
                        .DefaultIfEmpty(0)
                        .Average(),
                    TestCount = results
                        .Count(r => r.StudentId == user.Id),
                    LastTestDate = results
                        .Where(r => r.StudentId == user.Id)
                        .OrderByDescending(r => r.SubmissionDate)
                        .Select(r => r.SubmissionDate)
                        .FirstOrDefault()
                })
                .OrderByDescending(s => s.AverageScore)
                .ToList();

            dgvStudents.DataSource = ratings;
        }
        private void ApplyMedals()
        {
            for (int i = 0; i < dgvStudents.Rows.Count; i++)
            {
                if (i == 0)
                    dgvStudents.Rows[i].DefaultCellStyle.BackColor = Color.Gold; // 🥇
                else if (i == 1)
                    dgvStudents.Rows[i].DefaultCellStyle.BackColor = Color.Silver; // 🥈
                else if (i == 2)
                    dgvStudents.Rows[i].DefaultCellStyle.BackColor = Color.Peru; // 🥉
            }
        }
        private void ApplyColorByScore()
        {
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.Cells["AverageScore"].Value != null)
                {
                    double score = Convert.ToDouble(row.Cells["AverageScore"].Value);

                    if (score >= 80)
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (score >= 50)
                        row.DefaultCellStyle.BackColor = Color.Khaki;
                    else
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }
        private void DgvStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyColorByScore();
            ApplyMedals();
        }
        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.csv";
            saveFileDialog.Title = "Сохранить рейтинг учеников";
            saveFileDialog.FileName = "Рейтинг_учеников.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // Заголовки
                        for (int i = 0; i < dgvStudents.Columns.Count; i++)
                        {
                            sw.Write(dgvStudents.Columns[i].HeaderText);
                            if (i < dgvStudents.Columns.Count - 1) sw.Write(";");
                        }
                        sw.WriteLine();

                        // Данные
                        foreach (DataGridViewRow row in dgvStudents.Rows)
                        {
                            for (int i = 0; i < dgvStudents.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                    sw.Write(row.Cells[i].Value.ToString());

                                if (i < dgvStudents.Columns.Count - 1) sw.Write(";");
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("Экспорт завершен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvStudents.Rows[e.RowIndex];
                var fullName = selectedRow.Cells["FullName"].Value.ToString();

                // Найти ID ученика
                var student = _dbContext.Users
                    .FirstOrDefault(u => (u.FirstName + " " + u.LastName) == fullName && u.RoleId == 1);

                if (student != null)
                {
                    var progressForm = new ProgressChartForm(student.Id, fullName, _dbContext);
                    progressForm.ShowDialog();
                }
            }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.Cells["FullName"].Value != null &&
                    row.Cells["FullName"].Value.ToString().ToLower().Contains(searchText))
                {
                    row.Selected = true;
                    dgvStudents.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }

            MessageBox.Show("Ученик не найден.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
