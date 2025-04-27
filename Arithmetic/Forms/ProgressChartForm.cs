using Arithmetic.Database;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // <<< ВАЖНО!

namespace Arithmetic.Forms
{
    public partial class ProgressChartForm : Form
    {

        public ProgressChartForm(int studentId, string fullName, AppDbContext dbContext)
        {
            this.studentId = studentId;
            this.studentFullName = fullName;
            this._dbContext = dbContext;

            InitializeComponent();
            LoadProgressChart();
        }
        private void ButtonSavePNG_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png";
                sfd.FileName = $"График_{studentFullName.Replace(" ", "_")}.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    chartProgress.SaveImage(sfd.FileName, ChartImageFormat.Png);
                    MessageBox.Show("График успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void LoadProgressChart()
        {
            var results = _dbContext.Results
                .Where(r => r.StudentId == studentId)
                .OrderBy(r => r.SubmissionDate)
                .Select(r => r.Score)
                .ToList();

            if (results.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения графика.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.chartProgress.Series.Clear(); // Очищаем серии

            // --- Серия для ЗАЛИВКИ (ШТРИХОВКИ)
            Series areaSeries = new Series
            {
                Name = "Область под графиком",
                ChartType = SeriesChartType.Area,
                Color = Color.FromArgb(100, Color.DeepSkyBlue), // Полупрозрачная заливка
                BorderWidth = 0
            };

            int testNumber = 1;
            foreach (var score in results)
            {
                areaSeries.Points.AddXY(testNumber++, score);
            }

            this.chartProgress.Series.Add(areaSeries);

            // --- Основная линия
            Series mainSeries = new Series
            {
                Name = "Результаты",
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.DeepSkyBlue,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10
            };

            testNumber = 1;
            foreach (var score in results)
            {
                mainSeries.Points.AddXY(testNumber++, score);
            }

            this.chartProgress.Series.Add(mainSeries);

            // --- Средняя линия
            double average = results.Average();
            Series avgSeries = new Series
            {
                Name = "Средний балл",
                ChartType = SeriesChartType.Line,
                BorderDashStyle = ChartDashStyle.Dash,
                BorderWidth = 2,
                Color = Color.Red,
            };
            avgSeries.Points.AddXY(1, average);
            avgSeries.Points.AddXY(results.Count, average);

            this.chartProgress.Series.Add(avgSeries);
        }




    }
}
