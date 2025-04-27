namespace Arithmetic.Forms
{
    partial class StudentsListForm
    {
        private DataGridView dgvStudents;
        private Button btnBack;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnExportExcel;

        private void InitializeComponent()

        {

            // 
            // btnExportExcel
            // 
            this.btnExportExcel = new Button();
            this.btnExportExcel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnExportExcel.Location = new Point(900, 635);
            this.btnExportExcel.Size = new Size(200, 40);
            this.btnExportExcel.Text = "Экспорт в Excel";
            this.btnExportExcel.Click += new EventHandler(this.BtnExportExcel_Click);

            this.Controls.Add(this.btnExportExcel);

            // 
            // txtSearch
            // 
            this.txtSearch = new TextBox();
            this.txtSearch.Location = new Point(400, 640);
            this.txtSearch.Size = new Size(300, 30);

            // 
            // btnSearch
            // 
            this.btnSearch = new Button();
            this.btnSearch.Text = "Поиск";
            this.btnSearch.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnSearch.Location = new Point(720, 635);
            this.btnSearch.Size = new Size(120, 40);
            this.btnSearch.Click += new EventHandler(this.BtnSearch_Click);

            // Добавляем на форму
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);

            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(12, 12);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(1100, 600);
            this.dgvStudents.TabIndex = 0;

            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(12, 630);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 50);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // StudentsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvStudents);
            this.Name = "StudentsListForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Рейтинг учеников";

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.dgvStudents.DataBindingComplete += DgvStudents_DataBindingComplete;

            this.dgvStudents.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvStudents_CellDoubleClick);

        }


    }
}