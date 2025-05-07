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
        private readonly IServiceScopeFactory _scopeFactory;

        public StudentsListForm(IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _scopeFactory = scopeFactory;
            LoadStudentsRating();
            ApplyColorByScore();
            ApplyMedals();
        }

        private void LoadStudentsRating()
        {
      
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var students = dbContext.Users
                    .Where(u => u.RoleId == 1)
                    .ToList(); 

                var results = dbContext.Results.AsEnumerable();

                var ratings = students
    .Select(user => {
        var userResults = results.Where(r => r.StudentId == user.Id).ToList();
        var lastResult = userResults
            .OrderByDescending(r => r.SubmissionDate)
            .FirstOrDefault();

        var lastTestName = lastResult != null
            ? dbContext.Tests.FirstOrDefault(t => t.Id == lastResult.TestId)?.Name
            : "—";

        return new
        {
            FullName = user.FirstName + " " + user.LastName,
            AverageScore = userResults.Select(r => (double?)r.Score).DefaultIfEmpty(0).Average(),
            TestCount = userResults.Count,
            LastTestDate = lastResult?.SubmissionDate,
            LastTestName = lastTestName
        };
    })
    .OrderByDescending(s => s.AverageScore)
    .ToList();

                dgvStudents.DataSource = ratings;
            }
        }

        private void ApplyMedals()
        {
            for (int i = 0; i < dgvStudents.Rows.Count; i++)
            {
                if (i == 0)
                    dgvStudents.Rows[i].DefaultCellStyle.BackColor = Color.Gold; 
                else if (i == 1)
                    dgvStudents.Rows[i].DefaultCellStyle.BackColor = Color.Silver; 
                else if (i == 2)
                    dgvStudents.Rows[i].DefaultCellStyle.BackColor = Color.Peru; 
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
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStudents.AutoResizeColumns();
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
                        for (int i = 0; i < dgvStudents.Columns.Count; i++)
                        {
                            sw.Write(dgvStudents.Columns[i].HeaderText);
                            if (i < dgvStudents.Columns.Count - 1) sw.Write(";");
                        }
                        sw.WriteLine();

                      
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

                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                  
                    var student = dbContext.Users
                        .FirstOrDefault(u => (u.FirstName + " " + u.LastName) == fullName && u.RoleId == 1);

                    if (student != null)
                    {
                        var progressForm = new ProgressChartForm(student.Id, fullName, dbContext);
                        progressForm.ShowDialog();
                    }
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
