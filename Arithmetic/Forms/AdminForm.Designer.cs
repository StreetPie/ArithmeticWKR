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

            // Цвета
            BlueButtonColor = Color.DodgerBlue;
            BlueButtonHoverColor = Color.DeepSkyBlue;
            RedButtonColor = Color.IndianRed;
            RedButtonHoverColor = Color.FromArgb(220, 20, 60);

            // Таблица учителей
            this.dataGridViewTeachers.Dock = DockStyle.Fill;
            this.dataGridViewTeachers.ReadOnly = true;
            this.dataGridViewTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeachers.MultiSelect = false;

            // Таблица учеников
            this.dataGridViewStudents.Dock = DockStyle.Fill;
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.MultiSelect = false;

            // TabControl
            this.tabControlUsers = new TabControl();
            this.tabControlUsers.Dock = DockStyle.Left;
            this.tabControlUsers.Width = 800;

            this.tabPageTeachers = new TabPage("Учителя");
            this.tabPageStudents = new TabPage("Ученики");

            this.tabPageTeachers.Controls.Add(this.dataGridViewTeachers);
            this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
            this.tabControlUsers.TabPages.Add(this.tabPageTeachers);
            this.tabControlUsers.TabPages.Add(this.tabPageStudents);

            // Панель с кнопками справа
            FlowLayoutPanel panelButtons = new FlowLayoutPanel();
            panelButtons.Dock = DockStyle.Right;
            panelButtons.Width = 300;
            panelButtons.FlowDirection = FlowDirection.TopDown;
            panelButtons.WrapContents = false;
            panelButtons.Padding = new Padding(10);
            panelButtons.AutoScroll = true;

            // Добавляем кнопки с отступами
            SetupButton(buttonAddUser, "Добавить пользователя", BlueButtonColor, ButtonAddUser_Click);
            SetupButton(buttonEditUser, "Изменить данные", BlueButtonColor, ButtonEditUser_Click);
            SetupButton(buttonDeleteUser, "Удалить пользователя", RedButtonColor, ButtonDeleteUser_Click);
            SetupButton(buttonResetPassword, "Сбросить пароль", RedButtonColor, ButtonResetPassword_Click);
            SetupButton(buttonMoveStudent, "Перевести ученика", BlueButtonColor, ButtonMoveStudent_Click);
            SetupButton(buttonAssignTeacherClasses, "Назначить классы учителю", BlueButtonColor, ButtonAssignTeacherClasses_Click);
            SetupButton(buttonCreateClass, "Создать класс", BlueButtonColor, ButtonCreateClass_Click);

            panelButtons.Controls.Add(buttonAddUser);
            panelButtons.Controls.Add(buttonEditUser);
            panelButtons.Controls.Add(buttonDeleteUser);
            panelButtons.Controls.Add(buttonResetPassword);
            panelButtons.Controls.Add(buttonMoveStudent);
            panelButtons.Controls.Add(buttonAssignTeacherClasses);
            panelButtons.Controls.Add(buttonCreateClass);

            // Правая панель (если используется)
            this.panelRightContainer.Dock = DockStyle.Right;
            this.panelRightContainer.Width = 340;
            this.panelRightContainer.BackColor = Color.FromArgb(240, 240, 240);
            this.panelRightContainer.Visible = false;

            // Настройки формы
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Админ-панель";

            // Добавление на форму
            this.Controls.Add(this.tabControlUsers);
            this.Controls.Add(panelButtons);
            this.Controls.Add(this.panelRightContainer);

            this.ResumeLayout(false);

            this.Load += AdminForm_Load;
            this.tabControlUsers.SelectedIndexChanged += (s, e) =>
            {
                if (tabControlUsers.SelectedTab == tabPageTeachers)
                    LoadTeachers();
                else if (tabControlUsers.SelectedTab == tabPageStudents)
                    LoadStudents();
            };
        }




        private void SetupButton(Button button, string text, Color baseColor, EventHandler onClick)
        {
            button.Text = text;
            button.Width = 260;
            button.Height = 40;
            button.Margin = new Padding(10);
            button.BackColor = baseColor;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            button.MouseEnter += (s, e) => button.BackColor = baseColor == BlueButtonColor ? BlueButtonHoverColor : RedButtonHoverColor;
            button.MouseLeave += (s, e) => button.BackColor = baseColor;
            button.Click += onClick;
        }


    }
}
