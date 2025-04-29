namespace Arithmetic.Forms
{
    partial class AdminForm
    {

        private System.Windows.Forms.Panel panelRightContainer;
        private System.Windows.Forms.DataGridView dataGridViewTeachers;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonEditUser;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonResetPassword;
        private System.Windows.Forms.Button buttonMoveStudent;
        private System.Windows.Forms.Button buttonAssignTeacherClasses;
        private System.Windows.Forms.Button buttonCreateClass;
        private TabControl tabControlUsers;
        private TabPage tabPageTeachers;
        private TabPage tabPageStudents;

        private System.ComponentModel.IContainer components = null;


        private Color BlueButtonColor = Color.DodgerBlue;
        private Color BlueButtonHoverColor = Color.DeepSkyBlue;
        private Color RedButtonColor = Color.IndianRed;
        private Color RedButtonHoverColor = Color.FromArgb(220, 20, 60);

        private void InitializeComponent()
        {

            this.dataGridViewTeachers = new DataGridView();
            this.dataGridViewStudents = new DataGridView();
            this.buttonAddUser = new Button();
            this.buttonEditUser = new Button();
            this.buttonDeleteUser = new Button();
            this.buttonResetPassword = new Button();
            this.buttonMoveStudent = new Button();
            this.buttonAssignTeacherClasses = new Button();
            this.buttonCreateClass = new Button();
            this.panelRightContainer = new Panel();



            // AdminForm
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Админ-панель";

            // Teachers Grid
            this.dataGridViewTeachers.Location = new Point(30, 30);
            this.dataGridViewTeachers.Size = new Size(540, 250);
            this.dataGridViewTeachers.ReadOnly = true;
            this.dataGridViewTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeachers.MultiSelect = false;

            // Students Grid
            this.dataGridViewStudents.Location = new Point(30, 300);
            this.dataGridViewStudents.Size = new Size(540, 250);
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.MultiSelect = false;

            // Buttons – placement beside grids
            int btnX = 600, btnY = 30, btnW = 200, btnH = 40, spacing = 50;
            SetupButton(buttonAddUser, "Добавить пользователя", btnX, btnY, btnW, btnH, BlueButtonColor, ButtonAddUser_Click);
            SetupButton(buttonEditUser, "Изменить данные", btnX, btnY + spacing, btnW, btnH, BlueButtonColor, ButtonEditUser_Click);
            SetupButton(buttonDeleteUser, "Удалить пользователя", btnX, btnY + spacing * 2, btnW, btnH, RedButtonColor, ButtonDeleteUser_Click);
            SetupButton(buttonResetPassword, "Сбросить пароль", btnX, btnY + spacing * 3, btnW, btnH, RedButtonColor, ButtonResetPassword_Click);
            SetupButton(buttonMoveStudent, "Перевести ученика", btnX, btnY + spacing * 4, btnW, btnH, BlueButtonColor, ButtonMoveStudent_Click);
            SetupButton(buttonAssignTeacherClasses, "Назначить классы учителю", btnX, btnY + spacing * 5, btnW, btnH, BlueButtonColor, ButtonAssignTeacherClasses_Click);
            SetupButton(buttonCreateClass, "Создать класс", btnX, btnY + spacing * 6, btnW, btnH, BlueButtonColor, ButtonCreateClass_Click);

            // Right panel container
            this.panelRightContainer.Location = new Point(830, 30);
            this.panelRightContainer.Size = new Size(340, 520);
            this.panelRightContainer.BackColor = Color.FromArgb(240, 240, 240);
            this.panelRightContainer.Visible = false;

            // Добавление на форму
            this.Controls.Add(this.dataGridViewTeachers);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonEditUser);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.buttonResetPassword);
            this.Controls.Add(this.buttonMoveStudent);
            this.Controls.Add(this.buttonAssignTeacherClasses);
            this.Controls.Add(this.buttonCreateClass);
            this.Controls.Add(this.panelRightContainer);

            this.ResumeLayout(false);
        }



        private void SetupButton(Button button, string text, int x, int y, int width, int height, Color baseColor, EventHandler onClick)
        {
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.BackColor = baseColor;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;

            button.MouseEnter += (s, e) => button.BackColor = baseColor == BlueButtonColor ? BlueButtonHoverColor : RedButtonHoverColor;
            button.MouseLeave += (s, e) => button.BackColor = baseColor;
            button.Click += onClick;
        }
    }
}
