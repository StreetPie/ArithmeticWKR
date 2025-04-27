using Arithmetic.Database;
using System.Windows.Forms.DataVisualization.Charting;

namespace Arithmetic.Forms
{
    partial class ProgressChartForm
    {
        private Chart chartProgress;
        private Label labelStudentName;
        private int studentId;
        private string studentFullName;
        private readonly AppDbContext _dbContext;
        private Button buttonSavePNG;


        private void InitializeComponent()
        {
            this.buttonSavePNG = new Button();
            this.buttonSavePNG.Text = "Сохранить график";
            this.buttonSavePNG.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.buttonSavePNG.Size = new Size(250, 50);
            this.buttonSavePNG.Location = new Point(700, 20);
            this.buttonSavePNG.Click += new EventHandler(ButtonSavePNG_Click);

            this.Controls.Add(this.buttonSavePNG);


            this.Text = "График успеваемости ученика";
            this.ClientSize = new Size(1000, 600);

            this.labelStudentName = new Label();
            this.labelStudentName.Text = "Ученик: " + studentFullName;
            this.labelStudentName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.labelStudentName.Location = new Point(30, 20);
            this.labelStudentName.Size = new Size(900, 40);

            this.chartProgress = new Chart();
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Номер теста";
            chartArea.AxisY.Title = "Баллы (%)";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;


            this.chartProgress.ChartAreas.Add(chartArea);
            this.chartProgress.Location = new Point(30, 80);
            this.chartProgress.Size = new Size(920, 480);

            this.Controls.Add(this.labelStudentName);
            this.Controls.Add(this.chartProgress);
            chartProgress.SuppressExceptions = true;
            chartProgress.Annotations.Clear();

            foreach (var series in chartProgress.Series)
            {
                series.IsValueShownAsLabel = false;
                series.IsVisibleInLegend = false;
            }

            chartProgress.ChartAreas[0].AxisX.Interval = 1;
            chartProgress.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartProgress.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartProgress.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartProgress.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chartProgress.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartProgress.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartProgress.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartProgress.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartProgress.ChartAreas[0].CursorY.IsUserEnabled = true;
            chartProgress.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }
    } 
}
